<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TestSB.Pages.WebForm1" %>

<%@ Register Assembly="DevExpress.Web.v18.1, Version=18.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <dx:ASPxCallback ID="ASPxCallback1" runat="server" ClientInstanceName="Callback">
                        <ClientSideEvents CallbackComplete="function(s, e) { LoadingPanel.Hide(); }" />
                    </dx:ASPxCallback>
                    <dx:ASPxLoadingPanel ID="LoadingPanel" runat="server" ClientInstanceName="LoadingPanel" Text=""
                        Modal="True">
                        <Image Url="~/Content/Images/loading.gif">
                        </Image>
                    </dx:ASPxLoadingPanel>
          <dx:ASPxFormLayout runat="server" ID="formLayout" CssClass="formLayout">
            <SettingsAdaptivity AdaptivityMode="SingleColumnWindowLimit" SwitchToSingleColumnAtWindowInnerWidth="700" />
            <Items>
                <dx:LayoutGroup Caption="Información Requerida" ColCount="1" GroupBoxDecoration="HeadingLine" UseDefaultPaddings="false" Paddings-PaddingTop="10">
                    <GroupBoxStyle>
                        <Caption Font-Bold="true" Font-Size="16" />
                    </GroupBoxStyle>
                    <Items>
                        <dx:LayoutItem Caption="Ingrese su placa:">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTextBox runat="server" ID="txtPlaca" DisplayFormatString = "PKC7078">
                                        <ValidationSettings Display="Dynamic" ValidationGroup="infoSend" >
                                            <RequiredField ErrorText="Obligatorio" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTextBox>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Ingrese la fecha: ">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxDateEdit ID="date" runat="server" EditFormat="Custom" Caption="">
                                        <TimeSectionProperties>
                                            <TimeEditProperties EditFormatString="hh:mm tt" />
                                        </TimeSectionProperties>
                                        <CalendarProperties>
                                            <FastNavProperties DisplayMode="Inline" />
                                        </CalendarProperties>
                                        <ValidationSettings Display="Dynamic" ValidationGroup="infoSend" >
                                            <RequiredField ErrorText="Obligatorio" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxDateEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                        <dx:LayoutItem Caption="Ingrese la hora:">
                            <LayoutItemNestedControlCollection>
                                <dx:LayoutItemNestedControlContainer>
                                    <dx:ASPxTimeEdit ID="time" runat="server" DateTime="2009/11/01 15:31:34">
                                        <ClearButton DisplayMode="OnHover"></ClearButton>
                                        <ValidationSettings Display="Dynamic" ValidationGroup="infoSend" >
                                            <RequiredField ErrorText="Obligatorio" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxTimeEdit>
                                </dx:LayoutItemNestedControlContainer>
                            </LayoutItemNestedControlCollection>
                        </dx:LayoutItem>
                    </Items>
                </dx:LayoutGroup>
            </Items>
          </dx:ASPxFormLayout>
                    <div style="text-align: center">
                        <dx:ASPxButton ID="btnSearch" runat="server" OnClick="btnSearch_Click" ValidationGroup="infoSend" Style="background: #CC0000; color: white; width: 30%" Text="Consultar">
                            <Image IconID="actions_search_16x16devav"></Image>
                            <ClientSideEvents Click="function(s, e) {Callback.PerformCallback();LoadingPanel.Show();}" />
                        </dx:ASPxButton>
                    </div>
                    <dx:ASPxPopupControl ID="popupShowInfor" runat="server" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Modal="true" ShowCloseButton="false"
                        AllowDragging="True" HeaderImage-IconID="people_usergroup_16x16office2013" EnableTheming="True" HeaderText="Información Pico y Placa" ShowPageScrollbarWhenModal="true" Width="600px">
                        <HeaderStyle BackColor="#cd0c10" />
                        <ContentCollection>
                            <dx:PopupControlContentControl>
                                <dx:ASPxFormLayout runat="server" ID="ASPxFormLayout" Width="100%" ClientInstanceName="FormLayout">
                                    <Items>
                                        <dx:LayoutGroup Width="100%" Caption="Información de Pico y Placa" ColumnCount="2">
                                            <Items>
                                                <dx:LayoutItem Caption="">
                                                    <ParentContainerStyle Paddings-PaddingRight="12"></ParentContainerStyle>
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxImage ID="ImgMsg" runat="server" ShowLoadingImage="true" Width="100px"></dx:ASPxImage>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="">
                                                    <ParentContainerStyle Paddings-PaddingRight="12"></ParentContainerStyle>
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer>
                                                            <dx:ASPxLabel Font-Bold="true" Font-Size="Medium" ID="lblMsg" runat="server"></dx:ASPxLabel>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                            </Items>
                                        </dx:LayoutGroup>
                                    </Items>
                                </dx:ASPxFormLayout>
                                <div style="text-align: center">
                                    <dx:ASPxButton ID="btnClosePop" runat="server" ValidationGroup="infoSend" Style="background: #CC0000; color: white; width: 30%" Text="Cerrar">
                                        <Image IconID="actions_close_16x16devav"></Image>
                                        <ClientSideEvents Click="function(s, e) {Callback.PerformCallback();LoadingPanel.Show();}" />
                                    </dx:ASPxButton>
                                </div>
                            </dx:PopupControlContentControl>
                        </ContentCollection>
                    </dx:ASPxPopupControl>
                    <dx:ASPxPopupControl ID="poupMensaje" runat="server" ModalBackgroundStyle-Opacity="70" HeaderText="Información" EnableAnimation="false"
                        ShowCloseButton="false" ShowPageScrollbarWhenModal="true" Modal="true" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Style="font-weight: 700" Width="300px" Height="200px" CloseAction="None" ShowFooter="True" EnableTheming="False">
                        <HeaderStyle BackColor="#cd0c10" ForeColor="White" />
                        <ModalBackgroundStyle Opacity="70"></ModalBackgroundStyle>
                        <FooterTemplate>
                            <center>
                                <dx:ASPxButton ID="cmdClose" runat="server" Text="Salir"  Style="background: #cd0c10; color: white" OnClick="cmdClose_Click"  ValidationGroup="FALSE"></dx:ASPxButton>
                            </center>
                        </FooterTemplate>
                        <ContentCollection>
                            <dx:PopupControlContentControl runat="server">
                                <center>
                                <br />
                                <dx:ASPxImage ID="imgWarning" runat="server" ShowLoadingImage="true" Width="100px"></dx:ASPxImage>
                                <br />
                                <dx:ASPxLabel Font-Bold="true" Font-Size="Medium"  ID="lblWarning" runat="server"></dx:ASPxLabel>
                               </center>
                            </dx:PopupControlContentControl>
                        </ContentCollection>
                        </dx:ASPxPopupControl>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
