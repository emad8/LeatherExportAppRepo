﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="formLeatherCategory.aspx.cs" Inherits="LeatherApp.forms.formLeatherCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Form Leather Category</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Enter Details
                        </div>
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <form role="form">
                                        <div class="form-group input-group">
                                            <span class="input-group-addon">Name</span>
                                            <input type="text" class="form-control" placeholder="insert name...">
                                        </div>
                                        <div class="form-group input-group">
                                            <span class="input-group-addon">Description</span>
                                            <input type="text" class="form-control" placeholder="insert description...">
                                        </div>
                                        <button type="submit" class="btn btn-default">Submit Button</button>
                                    </form>
                                </div>
                                
                            </div>
                            <!-- /.row (nested) -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
        </div>
</asp:Content>
