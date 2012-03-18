App.Views.TodoListItem = Support.CompositeView.extend({

    tagName: 'li',
    templateName: 'todo-list-item',

    initialize: function () {
    },

    render: function () {
        this.renderTemplate();
        return this;
    },

    renderTemplate: function () {
        var html = this.buildTemplate(this.model.toJSON());
        $(this.el).html(html);
    }

});