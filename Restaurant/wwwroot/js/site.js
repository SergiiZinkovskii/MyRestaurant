class App {
    initDishTypeSelect($element) {
        let typesUrl = $element.data('types-url');

        $element.select2({
            placeholder: "Choose type",
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
    $('.dish-type-select').each(function () {
        app.initDishTypeSelect($(this));
    });
});