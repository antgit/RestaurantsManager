define("restaurantsService", ["jquery"], function ($) {
    function loadRestaurants(outcode) {
        return $.ajax({
            url: "/Home/GetRestaurants",
            type: "GET",
            data: { outcode: outcode }
        });
    }

    return {
        loadRestaurants: loadRestaurants
    }
});