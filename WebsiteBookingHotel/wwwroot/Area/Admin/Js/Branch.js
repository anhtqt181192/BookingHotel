var expried = new Date();
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
                        url: '/Admin/Branch/GetList',
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
                title: "Tên chi nhánh",
                width: 200,
                autoHide: false
            }, {
                field: "address",
                title: "Địa chỉ",
                width: 300,
            }, {
                field: "email",
                title: "Email",
            }, {
                field: "phone",
                class: "text-right",
                width: 100,
                title: "Điện thoại",
            }, {
                field: "fax",
                class: "text-right",
                width: 100,
                title: "FAX",
            }, {
                field: "hotline",
                class: "text-right",
                width: 100,
                title: "Hotline",
                
            }, {
                field: "modifyDate",
                title: "Ngày tạo",
                class: "text-center",
                width: 100,
                template: function(row){
                    var date = new Date(row.createDate);
                    var d = date.getDay();
                    var m = date.getMonth();
                    if (d < 10)
                        d = "0" + d;
                    if (m < 10)
                        m = "0" + m;
                    return d + "/" + m + "/" + date.getFullYear();
                }
            }, {
                field: "Id",
                width: 80,
                title: "",
                sortable: false,
                autoHide: false,
                overflow: 'visible',
                template: function (row) {
                    return '\
                            <a class="btn btn-sm btn-clean sync-branch" title="Đồng bộ"" data-id="' + row.id + '" >\
                                <i class="fas fa-sync-alt" ></i> Đồng bộ\
                            </a>\
                            ';
                }
            },  {
                field: "",
                width: 110,
                title: "",
                sortable: false,
                autoHide: false,
                overflow: 'visible',
                template: function (row) {
                    return '\
                    <a href="/Admin/Branch/edit?id=' + row.id + '" class="btn btn-sm btn-clean btn-icon btn-icon-md" title="Chỉnh sửa" >\
                        <i class="kt-nav__link-icon flaticon2-contract"></i>\
                    </a>\
                    <a class="btn btn-sm btn-clean btn-icon btn-icon-md removeCompanyButton" title="Xóa"" data-id="' + row.id + '" >\
                        <i class="kt-nav__link-icon flaticon2-trash"></i>\
                    </a>\
                    <a href="/Admin/Employee/Create?idBranch=' + row.id + '" class="btn btn-sm btn-clean btn-icon btn-icon-md" title="Thêm nhân viên" >\
                        <i class="fas fa-user-plus"></i>\
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
                    $.post("/Admin/branch/delete?id=" + id)
                        .done(function (data) {
                            if (data) {
                                datatable.reload();
                                swal.fire({
                                    title: 'Xóa thành công',
                                    text: 'Chi nhánh đã được xóa!',
                                    type: 'success',
                                    buttonsStyling: false,
                                    confirmButtonText: "OK",
                                    confirmButtonClass: "btn btn-sm btn-bold btn-brand"
                                });
                            }
                        });
                } else if (result.dismiss === 'cancel') {
                    swal.fire({
                        title: 'Hủy',
                        text: 'Hủy xóa thành công! :)',
                        type: 'error',
                        buttonsStyling: false,
                        confirmButtonText: "OK",
                        confirmButtonClass: "btn btn-sm btn-bold btn-brand",
                    });
                }
            });
        });
    }

    function initSyncBranch() {
        $(".sync-branch").click(function () {
            var id = $(this).attr("data-id");
            $.post("/Admin/Branch/SyncBranchCode", { id: id }, function (d) {
                if (d != "") {
                    expried = new Date(d.expireDate);
                    var now = new Date();
                    var time = new Date(expried - now);
                    $("#status-codex").html("* mã sẽ hết hạn sau " + time.getMinutes() + " phút " + time.getSeconds() + " giây");
                    $("#codex").html(d.codex);
                    $("#kt_modal_1").modal();
                }
            })
        });
    }

    function AddStyteToTable() {
        $("#kt_apps_user_list_datatable table").addClass("table-striped table-bordered");
    }

    var updateTotal = function () {
        datatable.on('kt-datatable--on-layout-updated', function () {
            initDelete();
            initSyncBranch();
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

function CountDown() {
    setTimeout(function () {
        CountDown();
        var now = new Date();
        if (now >= expried) {
            $("#kt_modal_1").modal('hide');
            return;
        }
        var time = new Date(expried - now);
        $("#status-codex").html("* mã sẽ hết hạn sau " + time.getMinutes() + " phút " + time.getSeconds() + " giây");
    }, 1000)
}

// On document ready
KTUtil.ready(function () {
    KTAppUserListDatatable.init();
    CountDown();
});

