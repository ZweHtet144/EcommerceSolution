    $('.carousel-item').f
var btn_id;
var Title;
var Price;
function fetch_data() {
    cart_item_count = localStorage.length;
    if (cart_item_count == 0) {//show & hide order tin yan button from user view
        document.getElementById('btn_direct_order').style.display = "block";
    }
    else {
        document.getElementById('btn_direct_order').style.display = "none";
    }
    document.getElementById('cart_item_quantity').innerText = cart_item_count;
}
function Add_To_Cart(obj) {
    btn_id = JSON.parse(obj).Id;
    Title = JSON.parse(obj).Title;
    Price = JSON.parse(obj).Price;
    //document.getElementById('temp').innerHTML = Title + Price;
    //console.log(btn_id);

    var class_name = document.getElementById(JSON.parse(obj).Id).className;

    if (class_name == "btn btn-primary") {
        document.getElementById('quantityModalLabel').innerText = 'စျေးခြင်းတောင်းထဲထည့်ရန်သေချာပါသလား ?';
        document.getElementById('modal_yes').innerText = 'သေချာပါပြီ။';
        document.getElementById('modal_no').innerText = 'မသေချာသေးပါ။';
    }
    else {
        document.getElementById('quantityModalLabel').innerText = 'စျေးခြင်းတောင်းထဲမှ ပစ္စည်းပြန်ထုတ်ရန်သေချာပြီလား?';
        document.getElementById('modal_yes').innerText = 'ပစ္စည်းဖယ်မည်။';
        document.getElementById('modal_no').innerText = 'ပစ္စည်းမဖယ်သေးပါ။';
    }

} //Add_To_Cart_Button Click
function Cart_Msg_Confirm() {
    var modal_yes_text = document.getElementById('modal_yes').innerText;
    var cart_item_count;
    if (modal_yes_text == "သေချာပါပြီ။") {
        document.getElementById(btn_id).className = 'btn btn-danger';
        document.getElementById(btn_id).innerText = 'Remove Item';
        var item_id = btn_id;
        var item = document.getElementById(item_id).innerText;
        localStorage.setItem(item_id, item);
        cart_item_count = localStorage.length;
        if (cart_item_count == 0) {//show & hide order tin yan button from user view
            document.getElementById('btn_direct_order').style.display = "block";
        }
        else {
            document.getElementById('btn_direct_order').style.display = "none";
        }
        document.getElementById('cart_item_quantity').innerText = cart_item_count;
        var _reqModel = {
            Id: btn_id,
            Title: Title,
            Price: Price
        };
        $.ajax({
            type: "POST",
            url: '/MainPage/AddtoCartItem',
            data: { 'model': _reqModel },
            dataType: "JSON",
            success: function () {
                /////////////
            }
        });
        document.getElementById('par').innerText = item;
        window.location = "/MainPage/OrderPage";


    } else {
        document.getElementById(btn_id).className = 'btn btn-primary';
        document.getElementById(btn_id).innerText = 'စျေးခြင်းထဲထည့်ရန်';
        var item_id = btn_id;
        var item = document.getElementById(item_id).innerText;
        localStorage.removeItem(item_id);
        cart_item_count = localStorage.length;
        if (cart_item_count == 0) {//show & hide order tin yan button from user view
            document.getElementById('btn_direct_order').style.display = "block";
        }
        else {
            document.getElementById('btn_direct_order').style.display = "none";
        }
        document.getElementById('cart_item_quantity').innerText = cart_item_count;
        var _modelId = {
            Id: btn_id
        };
        $.ajax({
            type: "POST",
            url: '/MainPage/RemoveAddtocartItem',
            data: { 'model': _modelId },
            dataType: "JSON",
            success: function () {
                //swal({
                //    title: "Success",
                //    text: "Order Successful",
                //    icon: "success",
                //});
            }
        });
        //document.getElementById('par').innerText = null;
    }

}
function GoOrder(obj) {
    Id = JSON.parse(obj).Id;
    Title = JSON.parse(obj).Title;
    Price = JSON.parse(obj).Price;
    var _reqModel = {
        Id: Id,
        Title: Title,
        Price: Price
    };
    $.ajax({
        type: "POST",
        url: '/MainPage/AddtoCartItem',
        data: { 'model': _reqModel },
        dataType: "JSON",
        success: function () {
            window.location.href = '/Cart_List';
        }
    });
}
//Cart_Msg_Confirm
var n = sessionStorage.getItem('on_load_counter');

if (n === null) {
    n = 0;
}
n++;
sessionStorage.setItem("on_load_counter", n);
if (n == 1) {
    localStorage.clear();
}

