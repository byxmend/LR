#include "circle.h"
#include "math.h"

Circle::Circle(QObject *parent) : Figure(parent)
{

}

Circle::~Circle()
{

}

QRectF Circle::boundingRect() const
{
    return QRectF(-820,-630,1640,1260);
}

void Circle::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    painter->setPen(QPen(QColor(15,140,163), 2));
    painter->drawEllipse(-R, -R, 2 * R, 2 * R);

    painter->setPen(QPen(QColor(15,140,0), 2));
    painter->setBrush(QBrush(QColor(15,140,0)));
    painter->drawEllipse(pointCenter.x() - 6, pointCenter.y() - 6, 12, 12);
        Q_UNUSED(option);
        Q_UNUSED(widget);
}
