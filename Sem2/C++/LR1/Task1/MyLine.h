#ifndef MYLINE_H
#define MYLINE_H

#include <QGraphicsItem>

class MyLine : public QGraphicsItem{
public:
    void paint(QPainter *painter, const QStyleOptionGraphicsItem *option, QWidget *widget);

    QRectF boundingRect() const;

    MyLine(int t_x1, int t_y1, int t_x2, int t_y2);

    MyLine();

private:
    int x1, y1, x2, y2;
};

#endif // MYLINE_H
