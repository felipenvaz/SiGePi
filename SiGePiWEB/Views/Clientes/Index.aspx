<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Clientes
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div><h1>Clientes</h1></div>
<table id="clientes"></table>

<div id="clienteAction" class="btn-custom" style="display:none;">
    <p id="idCliente" hidden="hidden" />
    <ul>
        <li id ="detalhesCliente">Detalhes</li>
        <li>Apagar</li>

    </ul>
</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ScriptsSection" runat="server">
    <script type="text/javascript">
        
        var body;
        
        body = "<%=ViewBag.Clientes%>";

        $("#clientes").html(body);

        $(".nome").click(function (e) {
            $('#clienteAction').css({ left: e.pageX, top: e.pageY, position: 'fixed' });
            $('#idCliente').text(this.id);
            $('#clienteAction').show();
        });

        $("#clienteAction").mouseleave(function () { $('#clienteAction').hide(); });

        $("#detalhesCliente").click(function () {
            $.ajax({
                type: "POST",
                url: "/Clientes/GetDadosCliente",
                data: "{ idCliente:"+ $('#idCliente').text()+" }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(xhr.responseText);
                    alert(thrownError);
                },
                success: function (cliente) {
                    alert(cliente.Nome);
                }
            });
        });

    </script>
</asp:Content>
