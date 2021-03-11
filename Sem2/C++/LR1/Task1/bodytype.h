#ifndef BODYTYPE_H
#define BODYTYPE_H
#include "MyLine.h"
#include <QKeyEvent>
#include <QObject>
#include <QDebug>

class BodyType : public QObject, public MyLine
{
    Q_OBJECT
private:
    int XBodyTopCoord;
    int YBodyTopCoord;

public:
    BodyType(int t_XBodyTopCoord, int t_YBodyTopCoord);

    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget);

    QRectF boundingRect() const;

    void keyPressEvent(QKeyEvent *event);

    QTimer *timer;
    QTimer *timer2;

public slots:
    void move();
    void move2();
};

#endif // BODYTYPE_H
