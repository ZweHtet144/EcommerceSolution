// var btn_id;
// function Add_To_Cart(id) {
//     btn_id=id;
//     var class_name = document.getElementById(id).className;
//     if (class_name == "btn btn-primary") {
//         document.getElementById('quantityModalLabel').innerText = 'စျေးခြင်းတောင်းထဲထည့်ရန်သေချာပါသလား ?';
//         document.getElementById('modal_yes').innerText = 'သေချာပါပြီ။';
//         document.getElementById('modal_no').innerText = 'မသေချာသေးပါ။';
//     } 
//     else {
//         document.getElementById('quantityModalLabel').innerText = 'စျေးခြင်းတောင်းထဲမှ ပစ္စည်းပြန်ထုတ်ရန်သေချာပြီလား?';
//         document.getElementById('modal_yes').innerText = 'ပစ္စည်းဖယ်မည်။';
//         document.getElementById('modal_no').innerText = 'ပစ္စည်းမဖယ်သေးပါ။';
//     }

// } //Add_To_Cart_Button Click
// function Cart_Msg_Confirm() {
//     var modal_yes_text = document.getElementById('modal_yes').innerText;
//     var cart_item_count;
//     if (modal_yes_text == "သေချာပါပြီ။") {
//         document.getElementById(btn_id).className = 'btn btn-danger';
//         document.getElementById(btn_id).innerText = 'Remove Item';
//         var item_id=btn_id.concat('_prod');
//         var item=document.getElementById(item_id).innerText;
//         sessionStorage.setItem(item_id,item);
//         cart_item_count = sessionStorage.length;
//         document.getElementById('cart_item_quantity').innerText = cart_item_count;
//     } else {
//         document.getElementById(btn_id).className = 'btn btn-primary';
//         document.getElementById(btn_id).innerText = 'စျေးခြင်းထဲထည့်ရန်';
//         var item_id=btn_id.concat('_prod');
//         var item=document.getElementById(item_id).innerText;
//         sessionStorage.removeItem(item_id);
//         cart_item_count = sessionStorage.length;
//         document.getElementById('cart_item_quantity').innerText = cart_item_count;
//     }

// } //Cart_Msg_Confirm
