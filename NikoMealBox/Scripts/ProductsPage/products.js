let btnLeft = document.querySelectorAll("#btn-left");
let btnRight = document.querySelectorAll("#btn-right");
let quantityInput = document.querySelectorAll("#quantity");
let addprodCart = document.querySelectorAll("#addProd");
let card = document.querySelectorAll(".card")
let titlename = document.querySelectorAll('.card-title')
let orderbtn = document.querySelector("#order");
let cartbtn = document.querySelector("#addProd");
let x = quantityInput.value;



function init() {//每一項產品加入id
    card.forEach(function (element, index) {
        element.setAttribute('id', "product" + index)
        console.log(element);
    })
}

function saveProd(titlename, price, quantity, key) {
    //正確
    //判斷localstorage有無同樣的key
    //若沒有 則新增key 新增資料到陣列
    //若有 則把資料新增到同key
    let cartArray = [];
    let cartprod = {
        prodName: titlename,
        quantity: quantity,
        price: price,
    }
    if (("product" + key) in localStorage) {//若有key
        let alreadyArray = JSON.parse(localStorage.getItem("product" + key))
        alreadyArray.push(cartprod)
        cartArray = alreadyArray;
    }
    else { //若沒有key
        cartArray.push(cartprod);
    }
    localStorage.setItem("product" + key, JSON.stringify(cartArray))
}


//寫在購物車頁(泉切的)
//下單
//cartbtn.addEventListener('click', function () {
//    var prodlenthjson = localStorage.length;
//    //取localstorage資料
//    var prodAryjson = localStorage.getItem("product" + prodlenthjson-1);
//    $.ajax({
//        url: '/Orders/Create', //資料要傳去的網址
//        type: 'Get', //請求方式，POST/GET。(預設為GET)
//        //data: {  //要傳入的參數NAME(KEY)&VALUE 傳送到server的資料
//        //    //prodAryjson
//        //    id:"product0",
//        //    prodName: "雞肉便當",
//        //    price: 50,
//        //    quantity:8
//        //},
//        dataType: 'json',//預期Server傳回的資料類型 
//        async: false,//請求同步
//        success: function (result) {//成功時Dosomething (程式只要可以執行成功)
//            alert(result)

//        }
//    })
//})



//按下購物車 利用動態id 取得text內容
addprodCart.forEach(function (element, index) {
    element.addEventListener('click', function () {
        let textElement = document.querySelector("#" + "product" + index + " .card-body .price")
        console.log(textElement)
        console.log(textElement.textContent);
        console.log(quantityInput[index].value);
        saveProd(titlename[index].textContent, textElement.textContent, quantityInput[index].value, index);
    })
})



btnLeft.forEach(function (element, index) {
    element.addEventListener('click', function () {
        if (quantityInput[index].value == 0) {
            return
        }
        quantityInput[index].value = parseInt(quantityInput[index].value) - 1;
    })
});

btnRight.forEach(function (element, index) {
    element.addEventListener('click', function () {
        quantityInput[index].value = parseInt(quantityInput[index].value) + 1;
    })
});

init()