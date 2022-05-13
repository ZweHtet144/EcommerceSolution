
function preventBack() {
        window.history.forward();
    }
setTimeout("preventBack()", 0);
window.onunload = function () {
    null;
}
$(document).ready(function () {
    var para = new URLSearchParams(window.location.search);
    var total = para.get("getTotalPrice");
    document.getElementById('totalPrice').innerHTML = total;
    //For Processing
    document.getElementById('getPrice').value = total;


    //var para1 = new URLSearchParams(window.location.search);
    //var totalQty = para1.get("getTotalQty");
    //document.getElementById('totalQty').innerHTML = totalQty;


});

$('#btnsend').click(function () {
    if ($('#name').val().length == 0) {
        alert('Name Required');
        return;
    }
    if ($('#phone').val().length == 0) {
        alert('Phone Required');
        return;
    }
    if ($('#city').val().length == 0) {
        alert('City Required');
        return;
    }
    if ($('#ward').val().length == 0) {
        alert('Ward Required');
        return;
    }
    if ($('#street').val().length == 0) {
        alert('Street Required');
        return;
    }
    if ($('#busstop').val().length == 0) {
        alert('BusStop Required');
        return;
    }

    var name = $('#name').val();
    var phone = $('#phone').val();
    var city = $('#city').val();
    var ward = $('#ward').val();
    var street = $('#street').val();
    var busstop = $('#busstop').val();
    var title = document.getElementById('ProductTitle').innerHTML;
    var totalPrice = document.getElementById('totalPrice').innerHTML;
    console.log(totalPrice);
    var _reqModel = {
        name: name,
        phone: phone,
        city: city,
        ward: ward,
        street: street,
        busstop: busstop,
        totalprice: totalPrice,
        title: title
    }
    $.ajax({
        type: "POST",
        url: '/MainPage/CheckOut',
        data: { 'model': _reqModel },
        dataType: "JSON",
        success: function () {
            swal({
                title: 'Success!',
                icon: 'success',
                text:'အော်ဒါမှာယူခြင်းအောင်မြင်ပါသည်l',
                type: 'success',
                allowOutsideClick: false,
                confirmButtonColor: '#3085d6',
                confirmButtonText: 'OK',
                allowEscapeKey: false
            }).then(function () {
                localStorage.clear();
                window.location.href="/MainPage/Popular";
            });
        }
    });
});   
