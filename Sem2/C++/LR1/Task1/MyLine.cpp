#include <QPainter>
#include <QStyleOptionGraphicsItem>
#include "MyLine.h"

MyLine::MyLine(int t_x1, int t_y1, int t_x2, int t_y2){
    x1 = t_x1;
    y1 = t_y1;
    x2 = t_x2;
    y2 = t_y2;
}

void MyLine::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget)
{
    painter->drawLine(x1, y1, x2, y2);
}

QRectF MyLine::boundingRect() const
{
    return QRectF(x1, y1, x2, y2);
}
