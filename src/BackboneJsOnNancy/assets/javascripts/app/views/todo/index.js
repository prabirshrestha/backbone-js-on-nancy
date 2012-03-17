App.Views.TodoIndex = Support.CompositeView.extend({

    templateName: 'todo-index',

    initialize: function () {
        this.todos = App.Data.Todos;
    },

    render: function () {
        this.renderTemplate();
        return this;
    },

    renderTemplate: function () {
        var html = this.buildTemplate();
        $(this.el).html(html);
    }

});