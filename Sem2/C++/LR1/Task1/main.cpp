#include <QApplication>
#include <QGraphicsScene>
#include "MyLine.h"
#include "Car.h"
#include "bodytype.h"
#include <QGraphicsView>

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);

    QGraphicsScene *scene = new QGraphicsScene(0, 0, 600, 600);

    Car *car = new Car(200, 200);
    BodyType *bodytype = new BodyType(203, 123);

    scene->addItem(car);
    scene->addItem(bodytype);

    bodytype->setFlag(QGraphicsItem::ItemIsFocusable);
    bodytype->setFocus();

    QGraphicsView *view = new QGraphicsView(scene);

    view->show();

    return a.exec();
}
