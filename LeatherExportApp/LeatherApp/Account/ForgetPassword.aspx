<%@ Page Title="Forget Your Password" Language="C#" MasterPageFile="~/MasterAccount.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="LeatherExportApp.Account.ForgetPassword" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p class="login-box-msg">Enter UserName to get Password</p>
        
            <asp:PasswordRecovery ID="RecoverPwd" runat="server">
                <MailDefinition
                    Subject="Your password has been reset...">
                </MailDefinition>
                <ValidatorTextStyle CssClass="error" />
                <SubmitButtonStyle CssClass="btn btn-primary" />

            </asp:PasswordRecovery>
            <p>
                Back to
            <asp:HyperLink runat="server" ID="LoginHyperLink" ViewStateMode="Disabled"> Log in</asp:HyperLink>
            </p>
        
    
</asp:Content>
