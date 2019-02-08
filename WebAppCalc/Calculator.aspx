<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="WebAppCalc.Calculator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="maindiv">
        <table class="box">
            <tr id="logo-row">
                <td><span id="logo"><sup>&copy;</sup>Calculator app</span></td>
                <td colspan="2"></td>
                <td>
                    <asp:RadioButton ID="rdoButton1" AutoPostBack="True" Value="Yes" GroupName="MeasurementSystem" Checked="true" runat="server" Text="Expression" OnCheckedChanged="Group1_CheckedChanged" />
                </td>
                <td>
                    <asp:RadioButton ID="rdoButton2" AutoPostBack="True" Value="No" GroupName="MeasurementSystem" runat="server" Text="Value" OnCheckedChanged="Group1_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:HiddenField ID="number1" runat="server" Value="0" />
                    <asp:HiddenField ID="number2" runat="server" Value="0" />
                    <asp:HiddenField ID="number3" runat="server" Value="0" />
                    <asp:HiddenField ID="act1" runat="server" Value="=" />
                    <asp:HiddenField ID="act2" runat="server" Value="=" />
                    <asp:HiddenField ID="ValueInMemory" runat="server" Value="0" />
                    <asp:TextBox Text="0" runat="server" CssClass="textbox" ID="UpperText" Visible="true" ReadOnly="true" />
                    <asp:TextBox Text="0" runat="server" CssClass="textbox" ID="Text1" Visible="false" ReadOnly="true" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="C" runat="server" CssClass="butt mult" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="M+" runat="server" CssClass="butt memory smaller-font" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="M-" runat="server" CssClass="butt memory smaller-font" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="/" runat="server" CssClass="butt mult_div" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="-" runat="server" CssClass="butt plus_min" OnClick="butt_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="←" runat="server" CssClass="butt mult" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="1" runat="server" CssClass="butt" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="2" runat="server" CssClass="butt" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="*" runat="server" CssClass="butt mult_div" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="+" runat="server" CssClass="butt plus_min" OnClick="butt_Click" />
                </td>

            </tr>
            <tr>
                <td>
                    <asp:Button Text="3" runat="server" CssClass="butt" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="4" runat="server" CssClass="butt" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="5" runat="server" CssClass="butt" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="^2" runat="server" CssClass="butt sqrt smaller-font" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="1/x" runat="server" CssClass="butt pow smaller-font" OnClick="butt_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="6" runat="server" CssClass="butt" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="7" runat="server" CssClass="butt" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="8" runat="server" CssClass="butt" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="√" runat="server" CssClass="butt sqrt" OnClick="butt_Click" />
                </td>
                <td rowspan="2">
                    <asp:Button Text="=" runat="server" CssClass="butt equal" OnClick="butt_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button Text="9" runat="server" CssClass="butt" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="0" runat="server" CssClass="butt" OnClick="butt_Click" />
                </td>
                <td>
                    <asp:Button Text="," runat="server" CssClass="butt" OnClick="butt_Click" />

                </td>
                <td>
                    <asp:Button Text="±" runat="server" CssClass="butt changesign smaller-font" OnClick="butt_Click" />
                </td>

            </tr>
        </table>
    </div>
</asp:Content>
