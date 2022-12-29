package com.example.medicinereminderapp.adapters;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.medicinereminderapp.R;
import com.example.medicinereminderapp.models.CustomPrescription;

import java.util.List;


public class MedicineAdapter extends RecyclerView.Adapter<MedicineAdapter.MedicineViewHolder> {

    private List<CustomPrescription> customPrescriptionList;
    private IClickItemCustom iClickItemCustom;

    public void setData(List<CustomPrescription> list){
        this.customPrescriptionList = list;
        notifyDataSetChanged();
    }

    public interface IClickItemCustom{
        void deleteCustom(CustomPrescription customPrescription);
    }
    public MedicineAdapter(IClickItemCustom iClickItemCustom){
        this.iClickItemCustom = iClickItemCustom;
    }

    @NonNull
    @Override
    public MedicineViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.st_item, parent, false);
        return new MedicineViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull MedicineViewHolder holder, int position) {
        CustomPrescription customPrescription = customPrescriptionList.get(position);
        if (customPrescription == null) {
            return;
        }
        holder.tvMedicineName.setText(customPrescription.getNameMedicine() + "    " +
                customPrescription.getHourDetailPrescription() + " : " +
                customPrescription.getMinuteDetailPrescription());
        holder.tvDescription.setText(customPrescription.getContentDetailPrescription());

        holder.btnDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                iClickItemCustom.deleteCustom(customPrescription);
            }
        });
    }

    @Override
    public int getItemCount() {
        if (customPrescriptionList != null) {
            return  customPrescriptionList.size();
        }
        return 0;
    }

    public class MedicineViewHolder extends RecyclerView.ViewHolder{
        private TextView tvMedicineName;
        private TextView tvDescription;
        private TextView tvtime;
        private ImageButton btnDelete;

        public MedicineViewHolder(@NonNull View itemView){
            super(itemView);

            tvMedicineName = itemView.findViewById(R.id.tv_a);
            tvDescription = itemView.findViewById(R.id.tv_b);
            btnDelete = itemView.findViewById(R.id.btn_delete);
        }
    }

//    private final Activity context;
////    private final ArrayList<String> id;
////    private final ArrayList<String> name;
////    private final ArrayList<String> image;
////    private final ArrayList<String> group;
////    private final ArrayList<Double> price;
//    private final ArrayList<CustomPrescription> customPrescriptions;
//
//    public MedicineAdapter(Activity context, ArrayList<CustomPrescription> customPrescriptions) {
//        super(context, R.layout.st_item);
//        this.context = context;
////        this.id = id;
////        this.name = name;
////        this.price = price;
////        this.image = image;
////        this.group = group;
//        this.customPrescriptions = customPrescriptions;
//    }
//
//    @NonNull
//    @Override
//    public View getView(int position, @Nullable View convertView, @NonNull ViewGroup parent) {
//        LayoutInflater inflater = context.getLayoutInflater();
//        View rootView = inflater.inflate(R.layout.st_item,null,true);
//        TextView txtId = rootView.findViewById(R.id.txtNamest);
//
//        Log.e("CustomPrescription Arrays: ", customPrescriptions.toString());
//
//        txtId.setText(customPrescriptions.get(position).getNameMedicine() + " - "
//                + customPrescriptions.get(position).getHourDetailPrescription());
//
////Hàm khởi thêm dữ lieu vào các View từ arrayList thông qua position
//        return rootView;
//    }
}
