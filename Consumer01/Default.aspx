<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Consumer01._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <%--<button onclick="doWork()" id="do-work">getWork</button>--%>

        <a class="btn btn-default" id="nuevo">Work</a>

        <div>
            <%--<select id="areas" onload="getAreas"></select>--%>
            <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        </div>
    </div>

    <script type="text/javascript">
        //function getAreas() {
        (function () {
            $.ajax({
                url: "Service/ServiceTest.svc/all",
                type: "GET",
                dataType: "json",
                success: function (data) {
                    $.each(data, function (index, v) {
                        $("#MainContent_DropDownList1").append('<option value=' + v.Id + '>' + v.Name + '</option>');
                    })
                },
                error: function (error) {
                    console.log(error);
                }
            });
        })();
            
         //}

        //function doWork() {
        //        //console.log('do work');
        //        //$("#nuevo").on('click', function () {

        //        //})
        //        $.ajax({
        //            url: "Service/ServiceTest.svc/DoWork",
        //            type: "GET",
        //            dataType: "json",
        //            success: function (data) {
        //                console.log(data);
        //            }
        //        });
        //    }
    </script>

</asp:Content>
