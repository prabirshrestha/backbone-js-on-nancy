App.Collections.Todos = Backbone.Collection.extend({

    model: App.Models.Todo,

    completed: function () {
        return _.select(this.models, function (model) {
            return model.get('status') === 'completed';
        });
    },

    incomplete: function () {
        return _.select(this.models, function(model) {
            return model.get('status') === 'incomplete';
        });
    }

});