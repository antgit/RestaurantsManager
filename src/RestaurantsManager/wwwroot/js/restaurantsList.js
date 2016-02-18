define("restaurantsList", ["jquery", "knockout"], function ($, ko) {
    function init() {
        var viewModel = new function () {
            var self = this;

            self.outcode = ko.observable("");
            self.outcode.subscribe(function (newValue) {
                self.loadRestaurants(newValue);
            });

            self.restaurants = ko.observableArray();

            self.loadRestaurants = function (outcode) {
                if (!outcode) {
                    return;
                }

                $.ajax({
                    url: "/Home/GetRestaurants",
                    type: "GET",
                    data: { outcode: outcode }
                }).done(function (data) {
                    self.restaurants(data);
                }).fail(function () {
                    console.error("Can't load restaurants data");
                });
            }

            self.onSubmit = function (e) {
                return false;
            }
        }

        ko.applyBindings(viewModel);
    }

    return {
        init: init
    }
});