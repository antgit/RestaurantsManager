requirejs.config({
    baseUrl: "/js",
    paths: {
        jquery: "../lib/jquery/dist/jquery.min",
        knockout: "../lib/knockout/dist/knockout",
        restaurantsList: "restaurantsList"
    },
    shim: {
        jquery: {
            exports: "$"
        },
        knockout: {
            exports: "ko"
        }
    }
});