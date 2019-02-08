<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SingIn.aspx.cs" Inherits="WebAppCalc.SingIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container" id="formOfRegistration">
        <h2>Fill the form please:</h2>       
        <asp:HiddenField ID="Hash" runat="server" Value="0" />
        <div class="row" id="mainFrameDiv" style="background-color: honeydew;">
            <div id="left" class="col-sm-6 sing">
                <span><sup>&copy;</sup>Calculator app helps you to perform arithmetic calculations.</span>
            </div>
            <div id="right" class="col-sm-6">
                <div class="row">
                    <div class="col-sm-6">
                        <asp:Button ID="Sing_in" Text="Sign In" runat="server" CssClass="signIn container selected-btn" OnClick="sing_regist_Click" />
                    </div>
                    <div class="col-sm-6">
                        <asp:Button ID="Regist" Text="Register" runat="server" CssClass="register container" OnClick="sing_regist_Click" />
                    </div>
                </div>
                <div class="form-group singin-form">
                    <label for="usernameoremail">Username or Email</label>
                    <asp:TextBox Text="" runat="server" CssClass="form-control" ID="usernameOrEmail" Visible="true" />
                </div>
                <div class="form-group ">
                    <label for="pwd">Password</label>
                    <asp:TextBox Text="" runat="server" CssClass="form-control" TextMode="password" ID="pwd" Visible="true" />
                </div>
                <div class="form-group form-check">
                    <div class="form-group form-check">
                        <label class="form-check-label">
                            <input class="form-check-input" type="checkbox" name="remember">
                            Remember me
                        </label>
                    </div>
                    <div class="row">
                        <asp:Button ID="submitButton" Text="Sing In" runat="server" CssClass="btn btn-success submitBut" OnClick="singIn_Click" />

                        <asp:Button ID="goForwardButton" Text="Go Forward!" runat="server" CssClass="btn btn-success submitBut" Visible="false" OnClick="GoForward_Click" />
                    </div>
                    <div class="row">
                        <asp:Button ID="ErrorButton" runat="server" Text="" Visible="true" CssClass="error-lab btn btn-success"></asp:Button>
                    </div>
                </div>
        </div>
    </div>
    </div>
   
</asp:Content>
