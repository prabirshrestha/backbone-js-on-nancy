Support.CompositeView = Support.CompositeView.extend({

    buildTemplate: function (model) {
        var template = JST[this.templateName];
        return template.render(model);
    }

});