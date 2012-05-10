App.Views.TodoIndex = Support.CompositeView.extend({

    templateName: 'todo-index',

    initialize: function () {
        _.bindAll(this, 'render');
    },

    render: function () {
        this.renderTemplate();
        this.renderFormTemplate();
        this.renderListTemplate();
        return this;
    },

    renderTemplate: function () {
        var html = this.buildTemplate();
        this.$el.html(html);
    },

    renderFormTemplate: function () {
        var view = new App.Views.TodoForm();
        this.renderChildInto(view, this.$('.content .form'));
    },

    renderListTemplate: function () {
        var view = new App.Views.TodoList({
            collection: this.collection
        });

        this.renderChildInto(view, this.$('.content .list'));
    }

});