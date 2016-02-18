define("restaurantsList", ["knockout", "restaurantsService"], function (ko, restaurantsService) {
    function init() {
        var viewModel = new function () {
            var self = this;

            self.outcode = ko.observable("");
            self.outcode.subscribe(function (newValue) {
                self.loadRestaurants(newValue);
            });

            self.busy = ko.observable(false);

            self.restaurants = ko.observableArray();

            self.loadRestaurants = function (outcode) {
                if (!outcode) {
                    return;
                }
                var promise = restaurantsService.loadRestaurants(outcode);

                self.busy(true);

                promise.done(function (data) {
                    self.restaurants(data);
                }).fail(function () {
                    console.error("Can't load restaurants data");
                }).always(function() {
                    self.busy(false);
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