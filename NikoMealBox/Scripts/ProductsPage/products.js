let btnLeft = document.querySelectorAll("#btn-left");
let btnRight = document.querySelectorAll("#btn-right");
let card = document.querySelectorAll(".card")
let titlename = document.querySelectorAll('.card-title')
let orderbtn = document.querySelector("#order");
let cartbtn = document.querySelector("#addProd");

let addprodCart = document.querySelectorAll("#addProd");
let quantityInput = document.querySelectorAll("#quantity");
let productId = document.querySelectorAll("#ProductId");

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



addprodCart.forEach(function (element, index) {
    //寫在購物車頁(泉切的)
    //下單
    element.addEventListener('click', function () {
        let inp_quantity = quantityInput[index].value;
        let prodId = productId[index].value;
        console.log(inp_quantity)
        $.ajax({
            url: '/Cart/AddToCart', //資料要傳去的網址
            type: 'post', //請求方式，POST/GET。(預設為GET)
            data: {
                id: prodId,
                quantity: inp_quantity
            }
        })
            .done(function (msg) {
                $('li#Cart').html(msg)
            });
     
    })
})




//按下購物車 利用動態id 取得text內容
//addprodCart.forEach(function (element, index) {
//    element.addEventListener('click', function () {
//        let textElement = document.querySelector("#" + "product" + index + " .card-body .price")
//        console.log(textElement)
//        console.log(textElement.textContent);
//        console.log(quantityInput[index].value);
//        saveProd(titlename[index].textContent, textElement.textContent, quantityInput[index].value, index);
//    })
//})



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