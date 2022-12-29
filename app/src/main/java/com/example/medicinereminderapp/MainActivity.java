package com.example.medicinereminderapp;

import android.app.Activity;
import android.app.AlarmManager;
import android.app.AlertDialog;
import android.app.PendingIntent;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.example.medicinereminderapp.adapters.MedicineAdapter;
import com.example.medicinereminderapp.api.ApiService;
import com.example.medicinereminderapp.database.CustomDatabase;
import com.example.medicinereminderapp.models.CustomPrescription;
import com.example.medicinereminderapp.models.DetailPrescription;
import com.example.medicinereminderapp.models.Medicine;
import com.example.medicinereminderapp.models.User;
import com.example.medicinereminderapp.services.AlarmReciver;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    private List<Medicine> mListMedicine;
    private Medicine mMedicine;
    private List<DetailPrescription> mListDetailPrescription;
    private DetailPrescription mDetailPrescription;
    private ArrayList<CustomPrescription> mListCustomPrescription;
    private CustomPrescription mCustomPrescription;
    private User user;

    private Bundle bundleReceiver;
    private EditText edtMName, edtMDescription, edtHour, edtMinute;
    private Button btnNew;
    private RecyclerView rcvCustom;
    private AlarmManager alarmManager;
    private PendingIntent pendingIntent;
    private MedicineAdapter medicineAdapter;
    private List<CustomPrescription> customPrescriptionList;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        bundleReceiver = getIntent().getExtras();
        if (bundleReceiver != null) {
            user = (User) bundleReceiver.get("obj_user");
        }

        initUi();

    }


    @Override
    protected void onStart() {
        super.onStart();

        mListMedicine = new ArrayList<>();
        getAllMedicine();

        mListCustomPrescription = new ArrayList<>();
        mListDetailPrescription = new ArrayList<>();
        getAllDetailPrescription();


        medicineAdapter = new MedicineAdapter(new MedicineAdapter.IClickItemCustom() {
            @Override
            public void deleteCustom(CustomPrescription customPrescription) {
                clickDeleteCustom(customPrescription);
            }
        });
        customPrescriptionList = new ArrayList<>();
        medicineAdapter.setData(customPrescriptionList);

        LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);
        rcvCustom.setLayoutManager(linearLayoutManager);
        rcvCustom.setAdapter(medicineAdapter);

        btnNew.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                addCustom();
            }
        });

        loadData();

    }

    private void clickDeleteCustom(final CustomPrescription customPrescription) {
        new AlertDialog.Builder(this)
                .setTitle("Comfirm Delete")
                .setMessage("Are you sure?")
                .setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        CustomDatabase.getInstance(MainActivity.this).customDAO().deleteCustom(customPrescription);
                        Intent intent = new Intent(MainActivity.this , AlarmReciver.class);
                        pendingIntent = PendingIntent.getBroadcast(
                                MainActivity.this,
                                0,
                                intent,
                                PendingIntent.FLAG_IMMUTABLE | PendingIntent.FLAG_UPDATE_CURRENT
                        );
                        if (pendingIntent == null) {
                            return;
                        }
                        pendingIntent.cancel();
                        Toast.makeText(MainActivity.this, "Delete success", Toast.LENGTH_SHORT).show();
                        loadData();
                    }
                }).setNegativeButton("No", null)
                .show();
    }

    private void loadData(){
        customPrescriptionList = CustomDatabase.getInstance(this).customDAO().getListCustom();
        medicineAdapter.setData(customPrescriptionList);
    }

    private void getAllDetailPrescription() {
        ApiService.apiService.getListDetailPrescription().enqueue(new Callback<List<DetailPrescription>>() {
            @Override
            public void onResponse(Call<List<DetailPrescription>> call, Response<List<DetailPrescription>> response) {
                mListDetailPrescription = response.body();
                if (mListDetailPrescription != null) {
                    Log.e("List DetailPrescription", mListDetailPrescription.size() + "");
                    String medicineName = "Example";

                    for (DetailPrescription detailPrescription : mListDetailPrescription){
                        if (detailPrescription.getIdUser() != null){
                            Log.e("DetailPrescription: ", detailPrescription.getIdUser());
                            if (detailPrescription.getIdUser().equals(user.getIdUser())) {
                                Log.e("User: ", user.getIdUser());
                                for (Medicine medicine : mListMedicine){

                                    if (medicine.getIdMedicine().equals(detailPrescription.getIdMedicine())){
                                        Log.e("detailPrescription: ", detailPrescription.getIdMedicine());
                                        Log.e("Medicine: ", medicine.getNameMedicine());
                                        medicineName = medicine.getNameMedicine();
                                    }
                                }
                                CustomPrescription customPrescription = new CustomPrescription(
                                        medicineName,
                                        detailPrescription.getContentDetailPrescription(),
                                        detailPrescription.getHourDetailPrescription(),
                                        detailPrescription.getMinuteDetailPrescription()
                                );
//                                Log.e("CustomPrescription: ", customPrescription.toString());
//                                mListCustomPrescription.add(customPrescription);

                                Calendar calendar = Calendar.getInstance();
                                calendar.setTimeInMillis(System.currentTimeMillis());
                                calendar.set(Calendar.HOUR_OF_DAY, detailPrescription.getHourDetailPrescription());
                                calendar.set(Calendar.MINUTE, detailPrescription.getMinuteDetailPrescription());
                                Intent intent = new Intent(MainActivity.this ,AlarmReciver.class);
                                intent.setAction("MyAction");
                                intent.putExtra("time",detailPrescription.getHourDetailPrescription()+" : "+detailPrescription.getMinuteDetailPrescription());
                                intent.putExtra("name",medicineName);
                                intent.putExtra("description",detailPrescription.getContentDetailPrescription());
                                alarmManager = (AlarmManager) getSystemService(ALARM_SERVICE);
                                pendingIntent = PendingIntent.getBroadcast(
                                        MainActivity.this,
                                        0,
                                        intent,
                                        PendingIntent.FLAG_IMMUTABLE | PendingIntent.FLAG_UPDATE_CURRENT
                                );

                                alarmManager.set(AlarmManager.RTC_WAKEUP, calendar.getTimeInMillis(), pendingIntent);

                                CustomDatabase.getInstance(MainActivity.this).customDAO().insertCustom(customPrescription);
                                Toast.makeText(MainActivity.this,"Add Success!",Toast.LENGTH_SHORT).show();

                                customPrescriptionList = CustomDatabase.getInstance(MainActivity.this).customDAO().getListCustom();
                                medicineAdapter.setData(customPrescriptionList);
                            }
                        }
                        }
                    //Log.e("mListCustomPrescription: ", mListCustomPrescription.toString());
//                    MedicineAdapter medicineAdapter = new MedicineAdapter(MainActivity.this,mListCustomPrescription);
//                    listView.setAdapter(medicineAdapter);
                }
            }

            @Override
            public void onFailure(Call<List<DetailPrescription>> call, Throwable t) {
                Toast.makeText(MainActivity.this, "Call Api Error!", Toast.LENGTH_SHORT).show();
            }
        });
    }

    private void getAllMedicine() {
        ApiService.apiService.getListMedicine().enqueue(new Callback<List<Medicine>>() {
            @Override
            public void onResponse(Call<List<Medicine>> call, Response<List<Medicine>> response) {
                mListMedicine = response.body();
                if (mListMedicine != null) {
                    Log.e("List Medicine", mListMedicine.size() + "");
                }
            }

            @Override
            public void onFailure(Call<List<Medicine>> call, Throwable t) {
                Toast.makeText(MainActivity.this, "Call Api Error!", Toast.LENGTH_SHORT).show();
            }
        });
    }

    private void addCustom() {
        String strName = edtMName.getText().toString().trim();
        String strDes = edtMDescription.getText().toString().trim();
        String strHour = edtHour.getText().toString().trim();
        String strMinute = edtMinute.getText().toString().trim();

        if (TextUtils.isEmpty(strName)||TextUtils.isEmpty(strDes)
                ||TextUtils.isEmpty(strHour)||TextUtils.isEmpty(strMinute)){
            return;
        }

        CustomPrescription customPrescription = new CustomPrescription(
                strName,
                strDes,
                Integer.parseInt(strHour),
                Integer.parseInt(strMinute)
        );
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(System.currentTimeMillis());
        calendar.set(Calendar.HOUR_OF_DAY, Integer.parseInt(strHour));
        calendar.set(Calendar.MINUTE, Integer.parseInt(strMinute));
        Intent intent = new Intent(MainActivity.this ,AlarmReciver.class);
        intent.setAction("MyAction");
        intent.putExtra("time",strHour+" : "+strMinute);
        intent.putExtra("name",strName);
        intent.putExtra("description",strDes);
        alarmManager = (AlarmManager) getSystemService(ALARM_SERVICE);
        pendingIntent = PendingIntent.getBroadcast(
                MainActivity.this,
                0,
                intent,
                PendingIntent.FLAG_IMMUTABLE | PendingIntent.FLAG_UPDATE_CURRENT
        );

        alarmManager.set(AlarmManager.RTC_WAKEUP, calendar.getTimeInMillis(), pendingIntent);

        CustomDatabase.getInstance(this).customDAO().insertCustom(customPrescription);
        Toast.makeText(this,"Add Success!",Toast.LENGTH_SHORT).show();

        hideSoftKeyboard();

        customPrescriptionList = CustomDatabase.getInstance(this).customDAO().getListCustom();
        medicineAdapter.setData(customPrescriptionList);

    }

    private void hideSoftKeyboard(){
        try{
            InputMethodManager inputMethodManager = (InputMethodManager) getSystemService(Activity.INPUT_METHOD_SERVICE);
            inputMethodManager.hideSoftInputFromWindow(getCurrentFocus().getWindowToken(), 0);
        } catch (NullPointerException ex){
            ex.printStackTrace();
        }
    }

    private void initUi() {
        edtMName = findViewById(R.id.edt_medicine_name);
        edtMDescription = findViewById(R.id.edt_medicine_description);
        edtHour = findViewById(R.id.edt_medicine_hour);
        edtMinute = findViewById(R.id.edt_medicine_minute);
        btnNew = findViewById(R.id.btn_new);
        rcvCustom = findViewById(R.id.rcv_custom);
    }
}