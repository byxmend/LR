#include "figure.h"
#include <QDebug>

Figure::Figure(QObject *parent) : QObject(parent), QGraphicsItem()
{
    timer = new QTimer();
    timer->setInterval(true);
    connect(timer, SIGNAL(timeout()), this, SLOT(scale(bool zoom)));
}

Figure::~Figure()
{

}

void Figure::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    painter->setPen(QPen(QColor(15,140,163), 3));
    painter->setBrush(QColor(15,140,163));

    for (int i = 1; i < (int)points.size(); i++) // рисуем саму линию
            painter->drawLine(points[i - 1], points[(i)]);

    if (paintDone && (int)points.size() > 0)
    {
        painter->setPen(QPen(QColor(123,174,0), 2));
        painter->setBrush(QBrush(QColor(153,204,0)));
        painter->drawEllipse(pointCenter.x() - 6, pointCenter.y() - 6, 12, 12);
    }

        Q_UNUSED(option); // надо для включения основных глобальных изменений (нужно для библиотек и их работы)
        Q_UNUSED(widget);
}

QRectF Figure::boundingRect() const
{
    return QRectF(-820,-630,1640,1260);
}

void Figure::setFlags() // для изменения элемента
{
    setFlag(QGraphicsItem::ItemIsMovable);
}

// Периметр и площадь
double Figure::getPerimeter()
{
    if (n == 0) //круг
        P = 2 * PI * R;
    else
    {
        int a = 0;
        P = 0;
        a = 2 * R * sin(PI / n);
        P = n * a;
    }
    return P / 6;
}

double Figure::getArea()
{
    if (n == 0)
        S = PI * R * R;
    else
        S = n * R * R * 0.5 * sin(2 * PI / n);
    return S / 36;
}

// Установка центра тяжести
void Figure::mouseDoubleClickEvent(QGraphicsSceneMouseEvent *event)
{
    setCenter(event->pos());
    emit signalChanges(); // дает сигнал, что у нас меняется действие (Н: двойной клик -> одинарный клик)
    QGraphicsItem::mouseDoubleClickEvent(event);
}

void Figure::setCenter(QPointF newCenter)
{
    emit signalChanges();
    pointCenter.setX(newCenter.x());
    pointCenter.setY(newCenter.y());
}

// Изменение размера и поворот
void Figure::changeSize(int valueN, int valueR) //Изменение радиуса
{
    n = valueN;
    R = valueR;

    if (!paintMode)
        points.clear();
    else
    {
        // Для произвольной фигуры R - не радиус, а коэффициент
        // Изначально передается R = 30; то есть 30 - 100%
        for (int i = 0; i < (int)points.size(); i++)
            points[i] = {pointCenter.x() + ((points[i].x() - pointCenter.x()) / percent) * (R / 30), pointCenter.y() + ((points[i].y() - pointCenter.y()) / percent) * (R / 30)};
        percent = R / 30; //запоминаем процент увеличения
    }
    update();
}

void Figure::rotation(int value)
{
    setTransform(QTransform().translate(pointCenter.x(), pointCenter.y()).rotate(value).translate(-pointCenter.x(), -pointCenter.y())); // видженты для отображения содержимого
}

// Рисование и перемещение мышью
void Figure::mousePressEvent(QGraphicsSceneMouseEvent *event)
{
    if (paintMode && !paintDone)
    {
        paintDone = false;
        points.clear();
        QPointF point = event->scenePos(); // расположение курсора на сцене
        points.push_back(point);
        startPoint = event->scenePos();
        previousPoint = event->scenePos();
        update();
    }
    else
    {
        cursorPressed(event);
        QGraphicsItem::mousePressEvent(event);
    }
}

void Figure::mouseMoveEvent(QGraphicsSceneMouseEvent *event)
{
    if (paintMode && !paintDone)
    {
        paintDone = false;
        QPointF point = event->scenePos();
        points.push_back(point);
        previousPoint = event->scenePos();
        update();
    }
    else
    {
        QGraphicsItem::mouseMoveEvent(event);
    }
}

void Figure::mouseReleaseEvent(QGraphicsSceneMouseEvent *event)
{
    if (paintMode && !paintDone)
    {
        paintDone = true;

        pointCenter = startPoint;

        update();
        emit signalChanges();
    }
    else
    {
        cursorReleased(event);
        QGraphicsItem::mouseReleaseEvent(event);
    }
}

void Figure::cursorPressed(QGraphicsSceneMouseEvent *event)
{
    this->setCursor(QCursor(Qt::ClosedHandCursor));
}

void Figure::cursorReleased(QGraphicsSceneMouseEvent *event)
{
    this->setCursor(QCursor(Qt::ArrowCursor));
}
