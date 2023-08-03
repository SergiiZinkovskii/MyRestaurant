class App {
    initProductTypeSelect($element) {
        let typesUrl = $element.data('types-url');

        $element.select2({
            placeholder: "Оберіть тип",
            minimumInputLength: 0,
            allowClear: true,
            dropdownParent: $element.parent(),
            ajax: {
                type: "POST",
                url: typesUrl,
                dataType: "json",
                processResults: function (result) {
                    return {
                        results: $.map(result, function (val, index) {
                            return {
                                id: index,
                                text: val
                            };
                        }),
                    };
                }
            }
        });
    }
}

window.app = new App();

$(function () {
    $('.product-type-select').each(function () {
        app.initProductTypeSelect($(this));
    });
});