package com.example.medicinereminderapp.services;

import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.os.Build;

import androidx.core.app.NotificationCompat;

import com.example.medicinereminderapp.R;

import java.util.Date;

public class AlarmReciver extends BroadcastReceiver {
    final String CHANNEL_ID = "204";
    @Override
    public void onReceive(Context context, Intent intent) {
        if (intent.getAction().equals("MyAction")){

            String time = intent.getStringExtra("time");
            String name = intent.getStringExtra("name");
            String description = intent.getStringExtra("description");

            NotificationManager notificationManager = (NotificationManager) context.getSystemService(context.NOTIFICATION_SERVICE);
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                NotificationChannel notificationChannel = new NotificationChannel(
                        CHANNEL_ID,
                        "Channel 1",
                        NotificationManager.IMPORTANCE_HIGH);
                        notificationChannel.setDescription("Description");
                        notificationManager.createNotificationChannel(notificationChannel);
            }
            NotificationCompat.Builder builder = new NotificationCompat.Builder(context, CHANNEL_ID)
                    .setContentTitle("Time to use "+name+"    "+time)
                    .setContentText("Description: "+description+"    "+time)
                    .setSmallIcon(R.drawable.ic_notifications)
                    .setColor(Color.RED)
                    .setCategory(NotificationCompat.CATEGORY_ALARM);

            if(notificationManager != null){
                notificationManager.notify(getNotificationId(), builder.build());
            }
        }
    }

    private int getNotificationId(){
        return (int) new Date().getTime();
    }
}
