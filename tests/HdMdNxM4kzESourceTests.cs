using FluentAssertions;
using Xunit;

namespace PepperDash.Essentials.DM.Tests;

/// <summary>
/// Source-level guards for HdMdNxM4kzEController. The controller needs a Crestron chassis to build,
/// so none of this can be exercised off-target; these pin the two source facts a later edit would
/// otherwise undo without anything noticing, both of which cost a working device its status or its
/// routes on real hardware.
/// </summary>
public class HdMdNxM4kzESourceTests
{
    private const string ChassisOnlineSubscription = "_chassis.OnlineStatusChange += Chassis_OnlineStatusChange";

    private static string Source()
    {
        var path = Path.GetFullPath(Path.Combine(
            AppContext.BaseDirectory, "..", "..", "..", "..", "src", "Chassis", "HdMdNxM4KzEController.cs"));

        File.Exists(path).Should().BeTrue($"the controller source should be at {path}");
        return File.ReadAllText(path);
    }

    [Fact]
    public void Subscribes_To_The_Chassis_Online_Event_Outside_LinkToApi()
    {
        // A system with no EISC bridge never calls LinkToApi, and this handler is what reads back the
        // routes the chassis already holds. Subscribed there, such a system shows no current route
        // until something switches again.
        var source = Source();

        var subscription = source.IndexOf(ChassisOnlineSubscription, StringComparison.Ordinal);
        var linkToApi = source.IndexOf("public override void LinkToApi", StringComparison.Ordinal);

        subscription.Should().BeGreaterThan(-1, "the controller must subscribe to the chassis online event");
        linkToApi.Should().BeGreaterThan(-1, "LinkToApi should still exist");
        subscription.Should().BeLessThan(linkToApi, "the subscription belongs in the constructor, not in LinkToApi");

        source.IndexOf(ChassisOnlineSubscription, subscription + 1, StringComparison.Ordinal)
            .Should().Be(-1, "subscribing twice would run the handler twice for every event");
    }

    [Theory]
    [InlineData("VideoDetectedFeedback.BoolValue")]
    [InlineData("HdcpSupportOnFeedback.BoolValue")]
    public void Reads_Per_Input_Sigs_Through_The_Guard(string read)
    {
        // A sig the chassis does not implement is not null - it throws when read - and these funcs run
        // for every feedback on every online event, so one unguarded read costs the device the rest.
        var source = Source();
        var index = source.IndexOf(read, StringComparison.Ordinal);

        index.Should().BeGreaterThan(-1, $"{read} should still be the value being read");

        while (index > -1)
        {
            var statement = source.Substring(Math.Max(0, index - 200), Math.Min(200, index));
            statement.Should().Contain("ReadSig(", $"{read} must be read through the guard");

            index = source.IndexOf(read, index + 1, StringComparison.Ordinal);
        }
    }
}
