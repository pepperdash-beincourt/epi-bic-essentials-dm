using FluentAssertions;
using PepperDash.Essentials.DM.Chassis;
using Xunit;

namespace PepperDash.Essentials.DM.Tests;

/// <summary>
/// The chassis reports its firmware, MAC address and host name from its own console, so the parse of
/// <c>ver</c> and <c>host</c> is what stands between a correct row and a blank one.
/// </summary>
public class CrestronConsoleReplyTests
{
    [Fact]
    public void Reads_firmware_date_and_mac_from_ver()
    {
        var reply = CrestronConsoleReply.ParseVer(
            "HD-MD4X1-4K-ZE Cntrl Eng [v1.0083.0020 (Mar 13 2023), #8A1B2C3D] @E-00107fe12345");

        reply.Version.Should().Be("1.0083.0020");
        reply.Date.Should().Be("Mar 13 2023");
        reply.MacAddress.Should().Be("00:10:7f:e1:23:45");
    }

    [Fact]
    public void Reads_ver_without_a_mac_and_with_surrounding_text()
    {
        var reply = CrestronConsoleReply.ParseVer("\r\nHD-MD4X1-4K-ZE Cntrl Eng [v1.0083.0020 (Mar 13 2023), #8A1B2C3D]\r\n");

        reply.Version.Should().Be("1.0083.0020");
        reply.MacAddress.Should().BeNull();
    }

    [Fact]
    public void Does_not_take_the_tsid_for_anything()
    {
        var reply = CrestronConsoleReply.ParseVer("X Cntrl Eng [v1.2 (Jan 1 2024), #00E2F1A0] @E-00107fe12345");

        reply.Version.Should().Be("1.2");
        reply.MacAddress.Should().NotContain("e2f1");
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("HD-MD4X1-4K-ZE>")]
    [InlineData("Bad or Incomplete Command")]
    [InlineData("Login:")]
    public void Anything_else_carries_no_version(string? text)
    {
        CrestronConsoleReply.ParseVer(text!).Version.Should().BeNull();
    }

    [Theory]
    [InlineData("Host Name: HD-MD4X1-4K-ZE-00107FE12345", "HD-MD4X1-4K-ZE-00107FE12345")]
    [InlineData("  host name : SWITCHER-1  \r", "SWITCHER-1")]
    public void Reads_the_host_name(string text, string expected)
    {
        CrestronConsoleReply.ParseHostName(text).Should().Be(expected);
    }

    [Theory]
    [InlineData("Host Name:")]
    [InlineData("HD-MD4X1-4K-ZE Cntrl Eng [v1.0083.0020 (Mar 13 2023), #8A1B2C3D]")]
    [InlineData("")]
    public void Anything_else_carries_no_host_name(string text)
    {
        CrestronConsoleReply.ParseHostName(text).Should().BeNull();
    }

    [Theory]
    [InlineData("00107FE12345", "00:10:7f:e1:23:45")]
    [InlineData("00107fe1234", null)]
    public void Formats_a_mac_address(string hex, string? expected)
    {
        CrestronConsoleReply.FormatMac(hex).Should().Be(expected);
    }
}
