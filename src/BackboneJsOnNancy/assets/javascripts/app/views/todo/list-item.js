App.Views.TodoListItem = Support.CompositeView.extend({

    tagName: 'li',
    templateName: 'todo-list-item',

    events: {
        'click span.todo-destroy': 'clear'
    },

    initialize: function () {
        _.bindAll(this, 'render', 'clear');
    },

    render: function () {
        this.renderTemplate();
        return this;
    },

    renderTemplate: function () {
        var html = this.buildTemplate(this.model.toJSON());
        $(this.el).html(html);
    },

    clear: function () {
        this.collection.remove(this.model);
    }

});