<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebAppCalc.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container" id="formOfRegistration">
        <h2>Fill the form please:</h2>

        <div class="row" id="mainFrameDiv" style="background-color: honeydew;">
            <div id="left" class="col-sm-6 reg">
                <span id="table-description"><sup>&copy;</sup>Calculator app helps you to perform arithmetic calculations.</span>
            </div>
            <div id="right" class="col-sm-6">
                <div class="row">
                    <div class="col-sm-6">
                        <asp:Button ID="SingIn" Text="Sign In" runat="server" CssClass="signIn container" OnClick="sing_regist_Click" />
                    </div>
                    <div class="col-sm-6">
                        <asp:Button ID="Regist" Text="Register" runat="server" CssClass="register container selected-btn" OnClick="sing_regist_Click" />
                    </div>                  
                </div>             
                <div class="form-group registration-form">
                    <label for="fullname">Full name</label>
                    <asp:TextBox Text="" runat="server" CssClass="form-control" ID="fullname" Visible="true" />                  
                </div>               
                <div class="form-group registration-form">
                    <label for="username">Username</label>
                    <asp:TextBox Text="" runat="server" CssClass="form-control" ID="username" Visible="true" />                  
                </div>
                <div class="form-group registration-form">
                    <label for="email">Email</label>
                    <asp:TextBox Text="" runat="server" CssClass="form-control" ID="email" Visible="true" />                  
                </div>
                <div class="form-group registration-form">
                    <label for="emailconfirmation">Email confirmation</label>
                    <asp:TextBox Text="" runat="server" CssClass="form-control" ID="emailconfirmation" Visible="true" />                 
                </div>
                <div class="form-group">
                    <label for="pwd">Password</label>
                    <asp:TextBox Text="" runat="server" CssClass="form-control" TextMode="Password" ID="pwd" Visible="true" />                  
                </div>
                <div class="form-group form-check">
                <div class="form-group form-check">
                    <label class="form-check-label">
                        <input class="form-check-input" type="checkbox" name="remember">
                        Remember me
                    </label>
                </div>
                <div>                  
                    <asp:Button ID="submitButton" Text="Registration" runat="server" CssClass="btn btn-success submitBut" OnClick="Registration_Click" />      
                 <div class="row">                       
                     <asp:Button ID="ErrorButton" runat="server" Text="qwdqwdqw"   Visible="true" CssClass="error-lab btn btn-success"></asp:Button>                     
                    </div>
                </div>
               
            </div>
        </div>
    </div>
     </div>
</asp:Content>
