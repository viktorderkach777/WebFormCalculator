<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RatesTable.aspx.cs" Inherits="WebAppCalc.RatesTable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title>Множественная привязка данных #1</title>
</head>
<body>
  <div class="row">
  <div class="col-sm-3"></div>
  <div class="col-sm-6" id="express">
      <asp:Button runat="server" Text="Enable table" OnClick="Unnamed_Click" class="EnableBut"/>
            <asp:DataGrid Enabled="false" runat="server" 
                ID="MyGrid" 
                DataSource="<%# Emps %>"
                AutoGenerateColumns="false"
                class="mygrid"
                Width="750px">
                
                <Columns >
                    <asp:TemplateColumn HeaderText="Digital Code" ItemStyle-Width="110px" HeaderStyle-CssClass="header-center">
                        <ItemTemplate>
                            <asp:TextBox
                                runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "DigitalCode") %>' CssClass="datarow"/>
                            <asp:HiddenField runat="server" Value="<%# Container.ItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                     <asp:TemplateColumn HeaderText="Letter Code" ItemStyle-Width="110px" HeaderStyle-CssClass="header-center">
                        <ItemTemplate>
                            <asp:TextBox
                                runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "LetterCode") %>' CssClass="datarow"/>
                            <asp:HiddenField runat="server" Value="<%# Container.ItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Number of Units" ItemStyle-Width="110px" HeaderStyle-CssClass="header-center">
                        <ItemTemplate>
                            <asp:TextBox
                                runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "NumberOfUnits") %>' CssClass="datarow"/>
                            <asp:HiddenField runat="server" Value="<%# Container.ItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Currency Name" ItemStyle-Width="210px" HeaderStyle-CssClass="header-center">
                        <ItemTemplate>
                            <asp:TextBox
                                runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "CurrencyName") %>' CssClass="datarow"/>
                            <asp:HiddenField runat="server" Value="<%# Container.ItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                    <asp:TemplateColumn HeaderText="Official Exchange Rates" HeaderStyle-CssClass="header-center">
                        <ItemTemplate>
                            <asp:TextBox 
                                runat="server" 
                                Text='<%# DataBinder.Eval(Container.DataItem, "OfficialExchangeRates") %>'  CssClass="datarow"/>
                            <asp:HiddenField runat="server" Value="<%# Container.ItemIndex %>" />
                        </ItemTemplate>
                    </asp:TemplateColumn>
                </Columns>
            </asp:DataGrid>
  </div>
  <div class="col-sm-3"></div>
</div>
</body>
</html>
</asp:Content>
