<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebAppCalc.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>"ITStep"'s contact page.</h3>
    <address>
        "ITStep"<br />
        Rivne, UA <br />
        Pushkina 111 <br />
        <abbr title="Phone"></abbr>
       +38-067-00-00-000
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@itstep.ua</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@itstep.ua</a>
    </address>
</asp:Content>
