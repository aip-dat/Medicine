package com.example.medicinereminderapp.database;

import android.content.Context;

import androidx.room.Database;
import androidx.room.Room;
import androidx.room.RoomDatabase;

import com.example.medicinereminderapp.models.CustomPrescription;

@Database(entities = {CustomPrescription.class}, version = 1)
public abstract class CustomDatabase extends RoomDatabase {

    private static final String DATABASE_NAME = "CustomDatabase.db";
    private static CustomDatabase instance;

    public static synchronized CustomDatabase getInstance(Context context){
        if (instance == null) {
            instance = Room.databaseBuilder(
                    context.getApplicationContext(),
                    CustomDatabase.class,
                    DATABASE_NAME
            ).allowMainThreadQueries().build();
        }
        return instance;
    }

    public abstract CustomDAO customDAO();
}
