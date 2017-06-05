<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxDemo.aspx.cs" Inherits="NetForm.Ajax.AjaxDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ajax省市县三级联动</title>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
    <script>
        $(function () { 
            //1.加载省的数据
            $("#selProvince").load("Ajax/SelectProvinceHandler.ashx", function (data) {
                if (data != null) {
                    $(this).html(data);
                }
            });

            //2.加载选择省下面的市数据
            $("#selProvince").change(function () {
                $.ajax({
                    type: "get",//请求类型
                    url: "Ajax/SelectCityHandler.ashx",//请求URL地址
                    data: "ProvinceId=" + $(this).val(),//请求参数
                    success: function (result) {
                        if (result != null && result != "")
                            $("#selCity").html(result);
                    }//请求成功的函数回调
                });
            });
        })
    </script>
</head>
<body>
    <h1>Ajax省市县三级联动</h1>
    <form id="form1" runat="server">
        <div>
            省：<select id="selProvince"></select>
            市：<select id="selCity"></select>
            县：<select id="selDistrict"></select>
        </div>
    </form>


</body>
</html>
