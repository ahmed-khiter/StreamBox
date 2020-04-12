function confirmDelete(uniqueId, isTrue) {
    var deleteSpan = "deleteSpan_" + uniqueId;
    var confirmDeleteSpan = "confirmDeleteSpan_" + uniqueId;

    if (isTrue) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    }else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}


//var ConfirmDelete = function (UserId) {
//    $("hiddenUserId").val(UserId);
//    $("#exampleModal").modal('show');
//}

//var DeleteUser = function () {
//    //$("#loaderDiv").show();
//    var userid = $("#hiddenUserId").val();

//    $.ajax({
//        type: "POST", 
//        url: "/Adminstration/DeleteUser/hiddenUserId",
//        data: { id: userid },
//        success: function () {
//            //$("#loaderDiv").hide();
//            $("#exampleModal").modal("hide");
//        }

//    })
//}