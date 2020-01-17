#pragma checksum "C:\Users\anh.tran\source\repos\BookingHotel\WebsiteBookingHotel\Areas\Admin\Views\Dashboard\ListRoom.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2876657bc7d5b7e428a72284b9217141233a7891"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Dashboard_ListRoom), @"mvc.1.0.view", @"/Areas/Admin/Views/Dashboard/ListRoom.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/Dashboard/ListRoom.cshtml", typeof(AspNetCore.Areas_Admin_Views_Dashboard_ListRoom))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2876657bc7d5b7e428a72284b9217141233a7891", @"/Areas/Admin/Views/Dashboard/ListRoom.cshtml")]
    public class Areas_Admin_Views_Dashboard_ListRoom : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\anh.tran\source\repos\BookingHotel\WebsiteBookingHotel\Areas\Admin\Views\Dashboard\ListRoom.cshtml"
  
    ViewData["Title"] = "Danh sách phòng";
    Layout = "~/Areas/Admin/Views/Shared/_LayoutAdmin.cshtml";


#line default
#line hidden
            BeginContext(119, 3437, true);
            WriteLiteral(@"
<div class=""kt-content  kt-grid__item kt-grid__item--fluid"">
    <div class=""kt-grid__item kt-grid__item--fluid kt-grid kt-grid--hor"">

        <!-- begin:: Content Head -->
        <div class=""kt-subheader   kt-grid__item"" id=""kt_subheader"">
            <div class=""kt-subheader__main"">
                <h3 class=""kt-subheader__title"">
                    Công ty
                </h3>
                <span class=""kt-subheader__separator kt-subheader__separator--v""></span>
                <div class=""kt-subheader__group"" id=""kt_subheader_search"">
                    <form class=""kt-margin-l-20"" id=""kt_subheader_search_form"">
                        <div class=""kt-input-icon kt-input-icon--right kt-subheader__search"">
                            <input type=""text"" class=""form-control"" placeholder=""Tìm kiếm..."" id=""generalSearch"">
                            <span class=""kt-input-icon__icon kt-input-icon__icon--right"">
                                <span>
                                    <s");
            WriteLiteral(@"vg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" width=""24px"" height=""24px"" viewBox=""0 0 24 24"" version=""1.1"" class=""kt-svg-icon"">
                                        <g stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                            <rect id=""bound"" x=""0"" y=""0"" width=""24"" height=""24"" />
                                            <path d=""M14.2928932,16.7071068 C13.9023689,16.3165825 13.9023689,15.6834175 14.2928932,15.2928932 C14.6834175,14.9023689 15.3165825,14.9023689 15.7071068,15.2928932 L19.7071068,19.2928932 C20.0976311,19.6834175 20.0976311,20.3165825 19.7071068,20.7071068 C19.3165825,21.0976311 18.6834175,21.0976311 18.2928932,20.7071068 L14.2928932,16.7071068 Z"" id=""Path-2"" fill=""#000000"" fill-rule=""nonzero"" opacity=""0.3"" />
                                            <path d=""M11,16 C13.7614237,16 16,13.7614237 16,11 C16,8.23857625 13.7614237,6 11,6 C8.23857625,6 6,8.23857625 6,11 C6,13.7614237 8.23857625,16 11,16 ");
            WriteLiteral(@"Z M11,18 C7.13400675,18 4,14.8659932 4,11 C4,7.13400675 7.13400675,4 11,4 C14.8659932,4 18,7.13400675 18,11 C18,14.8659932 14.8659932,18 11,18 Z"" id=""Path"" fill=""#000000"" fill-rule=""nonzero"" />
                                        </g>
                                    </svg>

                                    <!--<i class=""flaticon2-search-1""></i>-->
                                </span>
                            </span>
                        </div>
                    </form>
                </div>
            </div>
            <div class=""kt-subheader__toolbar"">
                <a href=""/Admin/Dashboard/CreateRoom"" class=""btn btn-label-brand btn-bold"">
                    Thêm mới
                </a>
            </div>
        </div>

        <!-- end:: Content Head -->
        <!-- begin:: Content -->
        <div class=""kt-grid__item kt-grid__item--fluid"" id=""kt_content"">

            <!--begin::Portlet-->
            <div class=""kt-portlet kt-portlet--mobile"">
    ");
            WriteLiteral(@"            <div class=""kt-portlet__body kt-portlet__body--fit"">

                    <!--begin: Datatable -->
                    <table class=""table table-responsive"" id=""kt_apps_user_list_datatable"">
                    </table>

                    <!--end: Datatable -->
                </div>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3574, 8349, true);
                WriteLiteral(@"
    <script src=""/Area/Admin/assets/vendors/custom/datatables/datatables.bundle.js"" type=""text/javascript""></script>
    <script>
        var KTAppUserListDatatable = function () {

            // variables
            var datatable;

            // init
            var init = function () {
                // init the datatables. Learn more: https://keenthemes.com/metronic/?page=docs&section=datatable
                datatable = $('#kt_apps_user_list_datatable').KTDatatable({
                    // datasource definition
                    data: {
                        type: 'remote',
                        source: {
                            read: {
                                url: '/Admin/Dashboard/GetListRoom',
                            }
                        }
                    },

                    // layout definition
                    layout: {
                        scroll: false, // enable/disable datatable scroll both horizontal and vertical when needed.");
                WriteLiteral(@"
                        footer: false, // display/hide footer
                    },

                    // column sorting
                    sortable: true,

                    pagination: true,

                    search: {
                        input: $('#generalSearch'),
                        delay: 400
                    },

                    // columns definition
                    columns: [{
                        field: ""title"",
                        title: ""Tên phòng"",
                        width: 'auto',
                        autoHide: false
                    }, {
                        field: ""descriptions"",
                        title: ""Mô tả"",
                        width: 400,
                    }, {
                        field: ""addtional"",
                        title: ""Dịch vụ đi kèm"",
                        width: 100,
                        template: function (row) {
                            var addtional = row.addtional.split");
                WriteLiteral(@"("","");
                            var html = """";
                            for (var i = 0; i < addtional.length; i++) {
                                html += '<p><i class=""fas fa-check-square""></i> ' + addtional[i] + '</p>';
                            }
                            return html;
                        },
                    }, {
                        field: ""imageRoom"",
                        title: ""Hình ảnh phòng"",
                        template: function (row) {
                            return '<img src=""' + row.imageRoom + '"" class=""img-fluid"" style=""max-width: 100px; max-height: 200px"" />';
                        },
                    }, {
                        field: ""pirce"",
                        title: ""Giá"",
                        width: 100,
                    }, {
                        field: ""note"",
                        title: ""Ghi chú"",
                        width: 50,

                    }, {
                        field: ""id""");
                WriteLiteral(@",
                        width: 50,
                        title: ""#"",
                        sortable: false,
                        autoHide: false,
                        overflow: 'visible',
                        template: function (row) {
                            return '\
                        <a href=""/Admin/Dashboard/editRoom?id=' + row.id + '"" class=""btn btn-sm btn-clean btn-icon btn-icon-md"" title=""Chỉnh sửa"" >\
                            <i class=""kt-nav__link-icon flaticon2-contract""></i>\
                        </a>\
                        <a class=""btn btn-sm btn-clean btn-icon btn-icon-md removeCompanyButton"" title=""Xóa"""" data-id=""' + row.id + '"" >\
                            <i class=""kt-nav__link-icon flaticon2-trash""></i>\
                        </a>';
                        },
                    }]
                });
            };

            // search
            var search = function () {
                $('#kt_form_status').on('change', function");
                WriteLiteral(@" () {
                    datatable.search($(this).val().toLowerCase(), 'Status');
                });
            };

            // selection
            var selection = function () {
                // init form controls
                //$('#kt_form_status, #kt_form_type').selectpicker();

                // event handler on check and uncheck on records
                datatable.on('kt-datatable--on-check kt-datatable--on-uncheck kt-datatable--on-layout-updated', function (e) {
                    var checkedNodes = datatable.rows('.kt-datatable__row--active').nodes(); // get selected records
                    var count = checkedNodes.length; // selected records count

                    $('#kt_subheader_group_selected_rows').html(count);

                    if (count > 0) {
                        $('#kt_subheader_search').addClass('kt-hidden');
                        $('#kt_subheader_group_actions').removeClass('kt-hidden');
                    } else {
                        ");
                WriteLiteral(@"$('#kt_subheader_search').removeClass('kt-hidden');
                        $('#kt_subheader_group_actions').addClass('kt-hidden');
                    }
                });
            }


            // selected records delete
            function initDelete() {
                $("".removeCompanyButton"").click(function () {
                    var id = $(this).data(""id"");
                    swal.fire({
                        buttonsStyling: false,

                        text: ""Xác nhận muốn xóa ?"",
                        type: ""info"",

                        confirmButtonText: ""Xác nhận !"",
                        confirmButtonClass: ""btn btn-sm btn-bold btn-danger"",

                        showCancelButton: true,
                        cancelButtonText: ""Hủy bỏ"",
                        cancelButtonClass: ""btn btn-sm btn-bold btn-brand""
                    }).then(function (result) {
                        if (result.value) {
                            $.post(""/Admin/Dashb");
                WriteLiteral(@"oard/deleteRoom?id="" + id)
                                .done(function (data) {
                                    if (data) {
                                        datatable.reload();
                                        swal.fire({
                                            title: 'Xóa thành công',
                                            text: 'Phòng đã được xóa!',
                                            type: 'success',
                                            buttonsStyling: false,
                                            confirmButtonText: ""OK"",
                                            confirmButtonClass: ""btn btn-sm btn-bold btn-brand""
                                        });
                                    }
                                });
                        } else if (result.dismiss === 'cancel') {
                            swal.fire({
                                title: 'Cancelled',
                                text: 'Hủy xóa! :)',
");
                WriteLiteral(@"                                type: 'error',
                                buttonsStyling: false,
                                confirmButtonText: ""OK"",
                                confirmButtonClass: ""btn btn-sm btn-bold btn-brand"",
                            });
                        }
                    });
                });
            }

            function AddStyteToTable() {
                $(""#kt_apps_user_list_datatable table"").addClass(""table-striped table-bordered"");
            }

            var updateTotal = function () {
                datatable.on('kt-datatable--on-layout-updated', function () {
                    initDelete();
                });
            };

            return {
                // public functions
                init: function () {
                    init();
                    search();
                    updateTotal();
                    AddStyteToTable();
                },

            };

        }();

        v");
                WriteLiteral("ar datatable1\r\n        // On document ready\r\n        KTUtil.ready(function () {\r\n            KTAppUserListDatatable.init();\r\n        });\r\n\r\n\r\n    </script>\r\n");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
