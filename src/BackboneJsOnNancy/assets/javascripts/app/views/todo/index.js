App.Views.TodoIndex = Support.CompositeView.extend({

    templateName: 'todo-index',

    initialize: function () {
        _.bindAll(this, 'render');
        this.views = {};
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
        this.views.formView = new App.Views.TodoForm();
        this.renderChildInto(this.views.formView, this.$('.content .form'));
    },

    renderListTemplate: function () {
        this.views.listView = this.views.listView = new App.Views.TodoList({
            collection: this.collection
        });

        this.renderChildInto(this.views.listView, this.$('.content .list'));
    }

});