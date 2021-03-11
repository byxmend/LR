#include "bodytype.h"
#include <QPainter>
#include <MyLine.h>
#include <QBrush>
#include <QDebug>
#include <QTimer>

BodyType::BodyType(int XBodyTopCoord, int YBodyTopCoord):MyLine(0, 0, 0, 0), XBodyTopCoord(XBodyTopCoord), YBodyTopCoord(YBodyTopCoord){}

void BodyType::paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget){
    // body type
    painter->setPen(Qt::red);
    painter->drawLine(XBodyTopCoord,YBodyTopCoord,XBodyTopCoord+160,YBodyTopCoord);
    painter->drawLine(XBodyTopCoord,YBodyTopCoord+75,XBodyTopCoord+160,YBodyTopCoord+75);
    painter->drawLine(XBodyTopCoord,YBodyTopCoord,XBodyTopCoord,YBodyTopCoord+75);
    painter->drawLine(XBodyTopCoord+160,YBodyTopCoord,XBodyTopCoord+160,YBodyTopCoord+75);
}

void BodyType::keyPressEvent(QKeyEvent *event){

    timer = new QTimer;
    timer2 = new QTimer;

    if (event->key() == Qt::Key_Space){
        connect(timer,SIGNAL(timeout()),this,SLOT(move()));

        timer->start(50);
    }
    else if(event->key() == Qt::Key_R){

        connect(timer,SIGNAL(timeout()),this,SLOT(move2()));

        timer->start(50);
    }
}

void BodyType::move(){
    setPos(x(), y()-5);

    if (y() < YBodyTopCoord-175) timer->stop();
}

void BodyType::move2(){
    setPos(x(), y()+5);

    if (y() > YBodyTopCoord-125) timer->stop();
}

QRectF BodyType::boundingRect() const
{
    return QRectF(XBodyTopCoord, YBodyTopCoord, 160, 75);
}
