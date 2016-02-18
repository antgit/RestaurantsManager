requirejs.config({
    baseUrl: "/js",
    paths: {
        jquery: "../lib/jquery/dist/jquery.min",
        restaurantsList: "restaurantsList"
    },
    shim: {
        jquery: {
            exports: '$'
        }
    }
});