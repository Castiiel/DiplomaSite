$(function () {
    site.vm.customersPage = function () {
        var clock = new site.controls.Clock(),
            dataSource = new site.controls.DataSource({
                service: site.services.appliances,
                template: 'appliance.table'
            }),
            deleteCommand = ko.asyncCommand({
                execute: function (complete) {
                    if (confirm('Ви дійсно хочете видалити запис?')) {
                        site.logger.info('Вибачте дана функція ще не реалізована.');
                    }
                    complete();
                },
                canExecute: function (isExecuting) {
                    return !isExecuting && dataSource.currentItem;
                }
            }),
            editCommand = ko.asyncCommand({
                execute: function (complete) {
                    var item = dataSource.currentItem();
                    var edit = ko.validatedObservable(item);
                    formEdit.formContext.model(edit);
                    formEdit.open(complete);
                },
                canExecute: function (isExecuting) {
                    return !isExecuting && dataSource.currentItem;
                }
            }),
            addCommand = ko.asyncCommand({
                execute: function (complete) {
                    site.logger.info('Вибачте дана функція ще не реалізована.');

                    complete();
                },
                canExecute: function (isExecuting) {
                    return !isExecuting;
                }
            }),

                formEdit = new site.controls.FormEdit({
                    title: "Редегування запису",
                    templateUrl: "appliance.edit",
                    templateBuilder: new site.controls.TemplateBuilder({
                        //fields: [
                        //    { template: 'string', fieldName: 'Name', label: 'Наименование' },
                        //    { template: 'datetime', fieldName: 'CreateDate', label: 'Дата' },
                        //    { template: 'string', fieldName: 'Price', label: 'Цена' }
                        //]
                        templateUrlName: 'appliance.edit'
                    }),
                    events: {
                        onClosed: function (complete) {
                            if (complete) { complete(); }
                        },
                        onOpened: function () {

                        }
                    },
                    onSave: function (item) {
                        dataSource.putData(item, function (result) {
                            if (result) {
                                formEdit.close();
                                site.logger.success('Успішно оновлено');
                            }
                        });
                    },
                    onCancel: function (json) {

                        site.logger.info('Зміни документу відмінено!');
                    }
                });

        return {
            addCommand: addCommand,
            editCommand: editCommand,
            deleteCommand: deleteCommand,
            ds: dataSource,
            clock: clock
        }
    }();

    ko.applyBindings(site.vm.customersPage);
});