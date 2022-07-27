$(function ($) {
    "use strict";
    $.validator.addMethod('confirmvalue',
        function (value, element, params) {
            let expectedValue = params.expectedValue;
            if (!expectedValue) return false;

            let actual;
            if (element.type === "checkbox") {
                actual = element.checked;
                expectedValue = expectedValue === "True";
            } else {
                actual = element.value;
            }

            return expectedValue === actual;
        });

    $.validator.unobtrusive.adapters.add('confirmvalue', ['expectedvalue'],
        function (options) {
            options.rules['confirmvalue'] = {
                expectedValue: options.params['expectedvalue']
            };
            options.messages['confirmvalue'] = options.message;
        });
}(jQuery));