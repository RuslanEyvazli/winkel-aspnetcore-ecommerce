"use strict"


window.onload = function () {


  preloader.classList.add("hide");

  setTimeout(() => {
    preloader.classList.add("d-none");
  }, 500);

    if (localStorage.getItem("card-quantity") !== null) {
        $(".card-quantity").text(JSON.parse(localStorage.getItem("card-quantity")))
    }



//  if(localStorage.getItem("basket") === null)
//{
////     // create basket array in local storage
//    localStorage.setItem("basket", JSON.stringify([]));
//}
//const addToCart = [...document.querySelectorAll(".add")];
//const basketCart = document.getElementById("basket");
//const basket = JSON.parse(localStorage.getItem("basket"));
//const img = [...document.getElementsByTagName("img")];

//UpdateCart(basket);

//addToCart.forEach(btn =>{
//    btn.onclick = function(e){
//        //e.preventDefault();


//        const proid = this.getAttribute("proid");
//        const proname = this.getAttribute("data-proname");
//        const proprice = this.getAttribute("data-proprice");
//        let proImg=this.parentElement.previousElementSibling.getAttribute("src");

//        const product = {
//          id: proid,
//          name: proname,
//          price: proprice,
//          img: proImg
//        };
    
//        const basketParsed = JSON.parse (localStorage.getItem("basket"));

//        basketParsed.push(product);
//        UpdateCart(basketParsed);

//        localStorage.setItem("basket", JSON.stringify(basketParsed));
        
        
//    };
//})
//function UpdateCart(basket)
//{
//  basketCart.querySelector("span").innerText = basket.length;
//}
 




};

$(document).ready(function () {

//// add to basket
/// when window loads check user basket exits in local storage


        $(".menu").click(function(e){
            e.preventDefault();
            console.log("responsivliyin atasi nicat")

            $(".nav-mobile").toggleClass("active")
            $(".nav-mobile").toggleClass("d-none")
        })




 


   $("#woman .pilus").click(function(){

    let value = $(".changeable").text()
  value++;

   
   $(".changeable").text(value)


   })
   $("#woman .minus").click(function(){

    if($(".changeable").text() > 1 ){
        let value = $(".changeable").text()
        value--;
      
         
         $(".changeable").text(value)
    }

   


   })


$('.oc-1').owlCarousel({
    loop: true,
    margin: 10,
    nav: true,
    dots: true,
    autoplay: true,
    autoplayTimeout: 3000,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 1
        },
        1000: {
            items: 1
        }
    }
})
$('.oc-2').owlCarousel({
    loop: false,
    items:3,
    margin: 10,
    nav: true,
    dots: true,
    autoplay: true,
    autoplayTimeout: 3000,
    autoplayHoverPause: true,
    responsive: {
        0: {
            items: 1
        },
        600: {
            items: 1
        },
        1000: {
            items: 3
        }
    }
})
$('.loop').owlCarousel({
    center: true,
    items: 2,
    loop: true,
    margin: 10,
    center: true,
    responsive: {
        600: {
            items: 4
        }
    }
});
$('.nonloop').owlCarousel({
    center: true,
    items: 2,
    loop: false,
    margin: 10,
    responsive: {
        300:{
            items:1
        },
       
        600: {
            items: 3
        },
        1000: {
            items: 3
        }
    }
});

$(window).scroll(function () {
    let scroll = jQuery(window).scrollTop();

    if (scroll >= 400) {
        $("#navbar").addClass("sticky");
        $(".sticky .navright li.active a ").css("color", "#ffa45c");
        $(".sticky .navright li span.active ").css("color", "#ffa45c");
        $(".p-sticky li a ").css("color", "black");
        $("#navbar .navleft .navbar-brand").addClass("mbl")
        $(".nav-mobile").addClass("p-sticky")


        $(".sticky .navright li:last-of-type").addClass("cart");


        $("#navbar").css("top", "0px");
    }
    else {
        $("#navbar").removeClass("sticky")
        $("#navbar").css("top", "-50px")
        $(".p-sticky li a ").css("color", "white");
        $(".nav-mobile").removeClass("p-sticky")

        $(".navright li.active a ").css("color", "#000");
        $(".navright li:last-of-type").removeClass("cart");
        $(".navright li span.active ").css("color", "#000");
        $("#navbar .navleft .navbar-brand").removeClass("mbl")
    }
})
    let counters = [...document.querySelectorAll(".increasing span")];
    counters.forEach(counter => {
        let value = counter.getAttribute("data-count");


        let count = 0;
        count = parseInt(counter.innerHTML);

        setInterval(() => {
            if (count < value) {
                count = count + 1;
                counter.innerHTML = count;
            }
            else {
                clearInterval();
            }

        }, 0.0001);




    })

  
});

// Subscribe Form

const validateEmail = (email) => {
    return String(email)
        .toLowerCase()
        .match(
            /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|.(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        );
};
toastr.options.closeButton = true;
toastr.options.positionClass = "toast-bottom-right";
$("#subscribe").click(function (e) {
    e.preventDefault();
    var email = $(this).prev().val().trim();
    if (email && validateEmail(email)) {
        $.ajax({
            url: "/Ajax/Subscribe?email=" + email,
            method: "GET",
            success: function (res) {
                if (res.status === 200) {
                    toastr.success('You are successfully subscribed to our newsletter');
                    $("#subscribe").prev().val("");
                }
                else if (res.status === 410) {
                    
                    toastr.warning('This email exsits in our subscriber list');
                }
            }
        })
    }
    console.log(email);
});

//Add to cart ajax

$(".add").click(function (e) {
    e.preventDefault();

    $.ajax({
        url : $(this).attr("href"),
        method: "GET",
        success: function (res) {
            if (res.status === 200) {
                console.log(res.data)
                $(".card-quantity").text(res.data);
                localStorage.setItem("card-quantity", JSON.stringify(res.data))
                toastr.success("Product was successfully added to your cart");

            }
        }
    })
})
$(".close").parent().click(function (e) {
    e.preventDefault();
    var tr = $(this);
    $.ajax({
        url: $(this).attr("href"),
        method: "GET",
        success: function (res) {
            if (res.status === 200) {
                tr.parents("tr").remove();
                $(".card-quantity").text(res.data);
                localStorage.setItem("card-quantity", JSON.stringify(res.data))
                toastr.success("Product was successfully removed from cart");
            }
        }
    });
})
var skipCount = 3;
var totalCount = $("#loadmore").attr("data-total-count");
$("#loadmore").click(function () {
    $.ajax({
        url: "/Ajax/LoadProducts?skip=" + skipCount,
        method: "GET",
        success: function (res)
        {
            skipCount += 3;
            $(".products_row").append(res);

            console.log(typeof (res));
            if (skipCount >= totalCount) {
                $("#loadmore").parent().parent().remove();

            } 
        }
    });
});