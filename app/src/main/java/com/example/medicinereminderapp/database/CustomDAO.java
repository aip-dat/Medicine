package com.example.medicinereminderapp.database;

import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;

import com.example.medicinereminderapp.models.CustomPrescription;

import java.util.List;

@Dao
public interface CustomDAO {

    @Insert
    void insertCustom(CustomPrescription customPrescription);

    @Query("SELECT * FROM CustomPrescription")
    List<CustomPrescription> getListCustom();

    @Delete
    void deleteCustom(CustomPrescription customPrescription);
}
