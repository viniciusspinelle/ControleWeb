
//Aplica as Mascaras nos campos  
ko.bindingHandlers.masked = {
    init: function (element, valueAccessor, allBindingsAccessor) {
        var mask = allBindingsAccessor().mask || {};
        $(element).mask(mask, { placeholder: " " });
        ko.utils.registerEventHandler(element, 'focusout', function () {
            var observable = valueAccessor();
            observable($(element).val());
        });
    }
};

//Validação de email 
ko.validation.init({
    //insertMessages: false,
    //decorateElement: true,
    //parseInputAttributes: true,
    errorElementClass: 'has-error has-feedback'
});