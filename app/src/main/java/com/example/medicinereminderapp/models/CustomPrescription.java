package com.example.medicinereminderapp.models;

import androidx.room.Entity;
import androidx.room.PrimaryKey;

@Entity(tableName = "CustomPrescription")
public class CustomPrescription{

    @PrimaryKey(autoGenerate = true)
    private int id;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    private String nameMedicine;
    private String contentDetailPrescription;
    private int hourDetailPrescription;
    private int minuteDetailPrescription;

    public CustomPrescription(String nameMedicine, String contentDetailPrescription, int hourDetailPrescription, int minuteDetailPrescription) {
        this.nameMedicine = nameMedicine;
        this.contentDetailPrescription = contentDetailPrescription;
        this.hourDetailPrescription = hourDetailPrescription;
        this.minuteDetailPrescription = minuteDetailPrescription;
    }

    public String getNameMedicine() {
        return nameMedicine;
    }

    public void setNameMedicine(String nameMedicine) {
        this.nameMedicine = nameMedicine;
    }

    public String getContentDetailPrescription() {
        return contentDetailPrescription;
    }

    public void setContentDetailPrescription(String contentDetailPrescription) {
        this.contentDetailPrescription = contentDetailPrescription;
    }

    public int getHourDetailPrescription() {
        return hourDetailPrescription;
    }

    public void setHourDetailPrescription(int hourDetailPrescription) {
        this.hourDetailPrescription = hourDetailPrescription;
    }

    public int getMinuteDetailPrescription() {
        return minuteDetailPrescription;
    }

    public void setMinuteDetailPrescription(int minuteDetailPrescription) {
        this.minuteDetailPrescription = minuteDetailPrescription;
    }
}
