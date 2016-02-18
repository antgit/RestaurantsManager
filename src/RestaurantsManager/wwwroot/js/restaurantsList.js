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

            self.caption = ko.computed(function () {
                var restaurantsCount = self.restaurants()
                    .filter(function (r) { return r.isOpenNow; })
                    .length;

                var caption;

                switch (restaurantsCount) {
                    case 0:
                        caption = "No restaurants are";
                        break;
                    case 1:
                        caption = "1 restaurant is";
                        break;
                    default:
                        caption = restaurantsCount + " restaurants are";
                }

                return  caption + " currently available";
            });

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