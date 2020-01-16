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
                        url: '/Admin/Company/GetList',
                    }
                }
            },

            // layout definition
            layout: {
                scroll: false, // enable/disable datatable scroll both horizontal and vertical when needed.
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
                field: "name",
                title: "Tên công ty",
                width: 'auto',
                autoHide: false
            }, {
                field: "address",
                title: "Địa chỉ",
                width: 'auto',
            }, {
                field: "email",
                title: "Email",
            }, {
                field: "phone",
                title: "Điện thoại",
            }, {
                field: "fax",
                title: "FAX",
            }, {
                field: "hotline",
                title: "Hotline",
                
            }, {
                field: "modifyDate",
                title: "Ngày tạo",
                width: 'auto',
            }, {
                field: "Id",
                width: 110,
                title: "#",
                sortable: false,
                autoHide: false,
                overflow: 'visible',
                template: function (row) {
                    return '\
                    <a href="/Admin/company/edit?idCompany=' + row.id + '" class="btn btn-sm btn-clean btn-icon btn-icon-md" title="Chỉnh sửa" >\
                        <i class="kt-nav__link-icon flaticon2-contract"></i>\
                    </a>\
                    <a class="btn btn-sm btn-clean btn-icon btn-icon-md removeCompanyButton" title="Xóa"" data-id="' + row.id + '" >\
                        <i class="kt-nav__link-icon flaticon2-trash"></i>\
                    </a>\
                    <a href="/Admin/Branch/Create?idCompany=' + row.id + '" class="btn btn-sm btn-clean btn-icon btn-icon-md" title="Thêm chi nhánh" >\
                        <i class="kt-nav__link-icon flaticon-add"></i>\
                    </a>\
                    ';
                },
            }]
        });
    };

    // search
    var search = function () {
        $('#kt_form_status').on('change', function () {
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
                $('#kt_subheader_search').removeClass('kt-hidden');
                $('#kt_subheader_group_actions').addClass('kt-hidden');
            }
        });
    }


    // selected records delete
    function initDelete() {
        $(".removeCompanyButton").click(function () {
            var id = $(this).data("id");
            swal.fire({
                buttonsStyling: false,

                text: "Xác nhận muốn xóa ?",
                type: "info",

                confirmButtonText: "Xác nhận !",
                confirmButtonClass: "btn btn-sm btn-bold btn-danger",

                showCancelButton: true,
                cancelButtonText: "Hủy bỏ",
                cancelButtonClass: "btn btn-sm btn-bold btn-brand"
            }).then(function (result) {
                if (result.value) {
                    $.post("/Admin/company/delete?idCompany=" + id)
                        .done(function (data) {
                            if (data) {
                                datatable.reload();
                                swal.fire({
                                    title: 'Xóa thành công',
                                    text: 'Công ty đã được xóa!',
                                    type: 'success',
                                    buttonsStyling: false,
                                    confirmButtonText: "OK",
                                    confirmButtonClass: "btn btn-sm btn-bold btn-brand"
                                });
                            }
                        });
                } else if (result.dismiss === 'cancel') {
                    swal.fire({
                        title: 'Cancelled',
                        text: 'Hủy xóa thành công ! :)',
                        type: 'error',
                        buttonsStyling: false,
                        confirmButtonText: "OK",
                        confirmButtonClass: "btn btn-sm btn-bold btn-brand",
                    });
                }
            });
        });
    }

    function AddStyteToTable() {
        $("#kt_apps_user_list_datatable table").addClass("table-striped table-bordered");
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
var datatable1
// On document ready
KTUtil.ready(function () {
    KTAppUserListDatatable.init();
});

