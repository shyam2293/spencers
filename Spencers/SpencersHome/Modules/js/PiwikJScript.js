    var _paq = _paq || [];
    _paq.push(['addEcommerceItem',
                "2", // (required) SKU: Product unique identifier
                "Chang", // (optional) Product name
                "Condiments",
                19.0,
                1]);
    _paq.push(['trackEcommerceOrder',
                        "28", // (required) Unique Order ID
                        90, // (required) Order Revenue grand total (includes tax, shipping, and subtracted discount)
                        30, // (optional) Order sub total (excludes shipping)

        ]);
    _paq.push(['trackPageView']);
    _paq.push(['enableLinkTracking']);
    (function () {
        var u = "//impc1523/piwik/";
        _paq.push(['setTrackerUrl', u + 'piwik.php']);
        _paq.push(['setSiteId', 3]);
        var d = document, g = d.createElement('script'), s = d.getElementsByTagName('script')[0];
        g.type = 'text/javascript'; g.async = true; g.defer = true; g.src = u + 'piwik.js'; s.parentNode.insertBefore(g, s);
    })();
   