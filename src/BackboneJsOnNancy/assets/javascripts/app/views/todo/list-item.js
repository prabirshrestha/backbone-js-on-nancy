App.Views.TodoListItem = Support.CompositeView.extend({

    tagName: 'li',
    templateName: 'todo-list-item',

    events: {
        'click span.todo-destroy': 'clear',
        'click :checkbox': 'toggleStatus',
        'dblclick div.todo-text': 'toggleEdit',
        'blur .todo-input': 'updateModel'
    },

    initialize: function () {
        _.bindAll(this, 'render', 'clear', 'toggleStatus', 'toggleEdit', 'updateModel');

        this.model.bind('change:content', this.render);
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
    },

    toggleStatus: function () {
        this.model.toggleStatus();
    },

    toggleEdit: function () {
        $(this.el).toggleClass('editing');
        this.$('input').focus();
    },

    updateModel: function () {
        $(this.el).toggleClass('editing');
        this.model.set({
            content: this.$('.todo-input').val()
        });
    }

});